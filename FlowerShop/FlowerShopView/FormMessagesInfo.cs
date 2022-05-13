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
    public partial class FormMessagesInfo : Form
    {
        private readonly IMessageInfoLogic _messageInfoLogic;
        int currentPage = 1;
        int countOnPage = 3;
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
                var list = _messageInfoLogic.Read(null).Skip(countOnPage * (currentPage - 1)).Take(countOnPage).ToList();
                if (list != null)
                {
                    dataGridView.DataSource = list;
                    dataGridView.Columns[0].Visible = false;
                    dataGridView.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
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
            int messagesCount = _messageInfoLogic.Read(null).Count;
            if ((countOnPage * currentPage) < messagesCount)
            {
                currentPage++;
            }
            LoadData();
        }

        private void textBoxPageNumber_TextChanged(object sender, EventArgs e)
        {
            if (textBoxPageNumber.Text != "")
            {
                currentPage = Convert.ToInt32(textBoxPageNumber.Text);
                LoadData();
            }
        }
    }
}
