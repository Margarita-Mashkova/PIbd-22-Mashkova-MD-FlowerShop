using FlowerShopConracts.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowerShopConracts.ViewModels
{
    // Сообщения, приходящие на почту
    public class MessageInfoViewModel
    {
        [Column(title: "Номер", width: 100)]
        public string MessageId { get; set; }

        [Column(title: "Отправитель", width: 150)]
        //[DisplayName("Отправитель")]
        public string SenderName { get; set; }

        [Column(title: "Дата письма", width: 100)]
        //[DisplayName("Дата письма")]
        public DateTime DateDelivery { get; set; }

        [Column(title: "Заголовок", width: 150)]
        //[DisplayName("Заголовок")]
        public string Subject { get; set; }

        [Column(title: "Текст", gridViewAutoSize: GridViewAutoSize.Fill)]
        //[DisplayName("Текст")]
        public string Body { get; set; }
    }
}
