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

namespace FlowerShopView
{
    public partial class FormStorehouseComponent : Form
    {
        private readonly IStorehouseLogic _logicS;
        private readonly IComponentLogic _logicC;
        public FormStorehouseComponent(IStorehouseLogic logicS, IComponentLogic logicC)
        {
            InitializeComponent();
            _logicS = logicS;
            _logicC = logicC;
        }
        private void FormStorehouseComponent_Load(object sender, EventArgs e)
        {
            try
            {
                List<StorehouseViewModel> storehouseList = _logicS.Read(null);
                if (storehouseList != null)
                {
                    comboBoxStorehouse.DisplayMember = "StorehouseName";
                    comboBoxStorehouse.ValueMember = "Id";
                    comboBoxStorehouse.DataSource = storehouseList;
                    comboBoxStorehouse.SelectedItem = null;
                }
                List<ComponentViewModel> componentList = _logicC.Read(null);
                if (componentList != null)
                {
                    comboBoxComponent.DisplayMember = "ComponentName";
                    comboBoxComponent.ValueMember = "Id";
                    comboBoxComponent.DataSource = componentList;
                    comboBoxComponent.SelectedItem = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (comboBoxStorehouse.SelectedValue == null)
            {
                MessageBox.Show("Выберите склад", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (comboBoxComponent.SelectedValue == null)
            {
                MessageBox.Show("Выберите компонент", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(textBoxCount.Text))
            {
                MessageBox.Show("Заполните количество", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                _logicS.AddComponent(new AddComponentBindingModel
                {
                    Id = Convert.ToInt32(comboBoxStorehouse.SelectedValue),
                    ComponentId = Convert.ToInt32(comboBoxComponent.SelectedValue),
                    Count = Convert.ToInt32(textBoxCount.Text)
                });
                MessageBox.Show("Сохранение прошло успешно", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
