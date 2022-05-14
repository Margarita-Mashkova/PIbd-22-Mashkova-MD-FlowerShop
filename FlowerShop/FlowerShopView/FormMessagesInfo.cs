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
    public partial class FormMessagesInfo : Form
    {
        private readonly IMessageInfoLogic _messageInfoLogic;
        int currentPage = 1;
        public FormMessagesInfo(IMessageInfoLogic messageInfoLogic)
        {
            InitializeComponent();
            _messageInfoLogic = messageInfoLogic;
        }

        private void FormMessagesInfo_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                var list = _messageInfoLogic.Read(new MessageInfoBindingModel
                {
                    PageNumber = currentPage
                });
                if (list != null)
                {
                    dataGridView.DataSource = list;
                    dataGridView.Columns[0].Visible = false;
                    dataGridView.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dataGridView.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dataGridView.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dataGridView.Columns[1].ReadOnly = true;
                }
                textBoxPageNumber.Text = currentPage.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void buttonBack_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--;
            }
            LoadData();
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            int stringsCountOnPage = _messageInfoLogic.Read(new MessageInfoBindingModel
            {
                PageNumber = currentPage + 1
            }).Count;

            if (stringsCountOnPage != 0)
            {
                currentPage++;
                LoadData();
            }            
        }

        private void textBoxPageNumber_TextChanged(object sender, EventArgs e)
        {
            if (textBoxPageNumber.Text != "")
            {
                int textBoxNumber = Convert.ToInt32(textBoxPageNumber.Text);
                int stringsCountOnPage = _messageInfoLogic.Read(new MessageInfoBindingModel
                {
                    PageNumber = textBoxNumber
                }).Count;

                if (textBoxNumber > 1 && stringsCountOnPage != 0)
                {
                    currentPage = textBoxNumber;
                    LoadData();
                }
            }
        }

        private void dataGridView_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                string id = dataGridView.SelectedRows[0].Cells[0].Value.ToString();
                var form = Program.Container.Resolve<FormMessageInfo>();
                form.MessageId = id;
                form.ShowDialog();
                LoadData();
            }
        }
    }
}
