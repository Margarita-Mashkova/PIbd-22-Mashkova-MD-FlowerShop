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
        int countOnPage = 3;
        int maxPage;
        public FormMessagesInfo(IMessageInfoLogic messageInfoLogic)
        {
            InitializeComponent();
            _messageInfoLogic = messageInfoLogic;
            CalcCountPages();
        }

        private void FormMessagesInfo_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            try
            {
                Program.ConfigGrid(_messageInfoLogic.Read(null).Skip(countOnPage * (currentPage - 1)).Take(countOnPage).ToList(), dataGridView);
                textBoxPageNumber.Text = currentPage.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void CalcCountPages()
        {
            int messagesCount = _messageInfoLogic.Read(null).Count;
            while ((countOnPage * (currentPage - 1)) < messagesCount)
            {
                if (currentPage > maxPage)
                {
                    maxPage = currentPage;
                }
                currentPage++;
            }
            labelMaxPage.Text = "из " + maxPage.ToString();
            currentPage = 1;
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
            if (currentPage < maxPage)
            {
                currentPage++;
            }
            LoadData();
        }

        private void textBoxPageNumber_TextChanged(object sender, EventArgs e)
        {            
            if (textBoxPageNumber.Text != "")
            {
                int textBoxNumber = Convert.ToInt32(textBoxPageNumber.Text);
                if (textBoxNumber < maxPage + 1)
                {
                    currentPage = Convert.ToInt32(textBoxPageNumber.Text);
                    LoadData();
                }
            }
        }

        private void dataGridView_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                string id = dataGridView.SelectedRows[0].Cells[0].Value.ToString();
                if (id != null)
                {
                    var form = Program.Container.Resolve<FormMessageInfo>();
                    form.MessageId = id;
                    form.ShowDialog();
                    LoadData();
                }
            }
        }
    }
}
