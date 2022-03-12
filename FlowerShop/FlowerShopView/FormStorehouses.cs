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
using Unity;

namespace FlowerShopView
{
    public partial class FormStorehouses : Form
    {
        private readonly IStorehouseLogic _logic;
        public FormStorehouses(IStorehouseLogic logic)
        {
            InitializeComponent();
            _logic = logic;
        }
        private void FormStorehouses_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            try
            {
                var list = _logic.Read(null);
                if (list != null)
                {
                    dataGridView.Rows.Clear();
                    foreach (var storehouse in list)
                    {
                        string strComponents = string.Empty;
                        foreach (var component in storehouse.StorehouseComponents)
                        {
                            strComponents += component.Value.Item1 + " = " + component.Value.Item2 + " шт.; ";
                        }
                        if (strComponents.Length != 0)
                        {
                            dataGridView.Rows.Add(new object[] { storehouse.Id, storehouse.StorehouseName, storehouse.ResponsibleFullName, storehouse.DateCreate, strComponents });
                        }
                        else
                        {
                            dataGridView.Rows.Add(new object[] { storehouse.Id, storehouse.StorehouseName, storehouse.ResponsibleFullName, storehouse.DateCreate });
                        }
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
            var form = Program.Container.Resolve<FormStorehouse>();
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }
        private void buttonUpd_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                var form = Program.Container.Resolve<FormStorehouse>();
                form.Id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value);
                if (form.ShowDialog() == DialogResult.OK)
                {
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
                    int id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value);
                    try
                    {
                        _logic.Delete(new StorehouseBindingModel { Id = id });
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
    }
}
