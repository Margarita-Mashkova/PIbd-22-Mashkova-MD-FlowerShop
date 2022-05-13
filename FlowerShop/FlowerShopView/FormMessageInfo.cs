using FlowerShopBusinessLogic.MailWorker;
using FlowerShopConracts.BindingModels;
using FlowerShopConracts.BusinessLogicsContracts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlowerShopView
{
    public partial class FormMessageInfo : Form
    {
        public string MessageId;
        private readonly IMessageInfoLogic _logic;
        private readonly AbstractMailWorker _mailWorker;
        public FormMessageInfo(IMessageInfoLogic logic, AbstractMailWorker mailWorker)
        {
            InitializeComponent();
            _logic = logic;
            _mailWorker = mailWorker;
        }

        private void FormMessageInfo_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            var message = _logic.Read(null).FirstOrDefault(rec => rec.MessageId.Equals(MessageId));
            if (message == null)
            {
                throw new Exception("Письмо не найдено");
            }
            labelSenderName.Text = "Отправитель: " + message.SenderName;
            labelSubject.Text = "Заголовок писмьа: " + message.Subject;
            labelBody.Text = "Текст письма: " + message.Body;
            labelDateDelivery.Text = "Доставлено: " + message.DateDelivery.ToString();
            textBoxReplySubject.Text = "Re: " + message.Subject;
            if (!string.IsNullOrEmpty(message.Reply))
            {
                buttonReply.Enabled = false;
                textBoxReply.Text = message.Reply;
            }
        }

        private void buttonReply_Click(object sender, EventArgs e)
        {
            _mailWorker.MailSendAsync(new MailSendInfoBindingModel
            {
                MailAddress = labelSenderName.Text,
                Subject = textBoxReplySubject.Text,
                Text = textBoxReply.Text
            });
            _logic.CreateOrUpdate(new MessageInfoBindingModel
            {
                MessageId = MessageId,
                Reply = textBoxReply.Text
            });
            MessageBox.Show("Письмо отправлено", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Close();
        }
    }
}
