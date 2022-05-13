using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FlowerShopConracts.BindingModels;
using FlowerShopConracts.BusinessLogicsContracts;
using FlowerShopConracts.ViewModels;
using Unity;

namespace FlowerShopView
{
    public partial class FormFlower : Form
    {
        public int Id { set { id = value; } }
        private readonly IFlowerLogic _logic;
        private int? id;
        private Dictionary<int, (string, int)> flowerComponents;
        public FormFlower(IFlowerLogic logic)
        {
            InitializeComponent();
            _logic = logic;
        }
        private void FormFlower_Load(object sender, EventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    FlowerViewModel view = _logic.Read(new FlowerBindingModel { Id = id.Value })?[0];
                    if (view != null)
                    {
                        textBoxName.Text = view.FlowerName;
                        textBoxPrice.Text = view.Price.ToString();
                        flowerComponents = view.FlowerComponents;
                        LoadData();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                flowerComponents = new Dictionary<int, (string, int)>();
            }
        }
        //TODO: доделать вывод
        private void LoadData()
        {
            try
            {
                if (flowerComponents != null)
                {
                    dataGridView.Rows.Clear();
                    foreach (var fc in flowerComponents)
                    {
                        dataGridView.Rows.Add(new object[] { fc.Key, fc.Value.Item1, fc.Value.Item2 });
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            var form = Program.Container.Resolve<FormFlowerComponent>();
            if (form.ShowDialog() == DialogResult.OK)
            {
                if (flowerComponents.ContainsKey(form.Id))
                {
                    flowerComponents[form.Id] = (form.ComponentName, form.Count);
                }
                else
                {
                    flowerComponents.Add(form.Id, (form.ComponentName, form.Count));
                }
                LoadData();
            }
        }
        private void buttonUpd_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                var form = Program.Container.Resolve<FormFlowerComponent>();
                int id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value);
                form.Id = id;
                form.Count = flowerComponents[id].Item2;
                if (form.ShowDialog() == DialogResult.OK)
                {
                    flowerComponents[form.Id] = (form.ComponentName, form.Count);
                    LoadData();
                }
            }
        }
        private void buttonDel_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                if (MessageBox.Show("Удалить запись", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        flowerComponents.Remove(Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    LoadData();
                }
            }
        }
        private void buttonRef_Click(object sender, EventArgs e)
        {
            LoadData();
        }
        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxName.Text))
            {
                MessageBox.Show("Заполните название", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(textBoxPrice.Text))
            {
                MessageBox.Show("Заполните цену", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (flowerComponents == null || flowerComponents.Count == 0)
            {
                MessageBox.Show("Заполните компоненты", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                _logic.CreateOrUpdate(new FlowerBindingModel
                {
                    Id = id,
                    FlowerName = textBoxName.Text,
                    Price = Convert.ToDecimal(textBoxPrice.Text),
                    FlowerComponents = flowerComponents
                });
                MessageBox.Show("Сохранение прошло успешно", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            }
        }
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
