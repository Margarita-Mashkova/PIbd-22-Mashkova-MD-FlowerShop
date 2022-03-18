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
    public partial class FormStorehouse : Form
    {
        public int Id { set { id = value; } }
        private readonly IStorehouseLogic _logic;
        private int? id;
        private Dictionary<int, (string, int)> storehouseComponents;
        public FormStorehouse(IStorehouseLogic logic)
        {
            InitializeComponent();
            _logic = logic;
        }
        private void FormStorehouse_Load(object sender, EventArgs e)
        {

            if (id.HasValue)
            {
                try
                {
                    StorehouseViewModel view = _logic.Read(new StorehouseBindingModel { Id = id.Value })?[0];
                    if (view != null)
                    {
                        textBoxName.Text = view.StorehouseName;
                        textBoxFIO.Text = view.ResponsibleFullName;
                        storehouseComponents = view.StorehouseComponents;
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
                storehouseComponents = new Dictionary<int, (string, int)>();
            }
        }
        private void LoadData() 
        {
            try
            {
                if (storehouseComponents != null)
                {
                    dataGridView.Rows.Clear();
                    foreach (var sc in storehouseComponents)
                    {
                        dataGridView.Rows.Add(new object[] { sc.Key, sc.Value.Item1, sc.Value.Item2 });
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxName.Text))
            {
                MessageBox.Show("Заполните название", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(textBoxFIO.Text))
            {
                MessageBox.Show("Заполните ФИО ответственного", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                _logic.CreateOrUpdate(new StorehouseBindingModel
                {
                    Id = id,
                    StorehouseName = textBoxName.Text,
                    ResponsibleFullName = textBoxFIO.Text,
                    DateCreate = DateTime.Now,
                    StorehouseComponents = storehouseComponents
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
