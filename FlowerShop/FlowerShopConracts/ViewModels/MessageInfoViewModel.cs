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
        public string MessageId { get; set; }

        [Column(title: "Прочитано", width: 75)]
        public bool IsRead { get; set; }

        [Column(title: "Отправитель", width: 195)]
        public string SenderName { get; set; }

        [Column(title: "Дата письма", width: 120)]
        public DateTime DateDelivery { get; set; }

        [Column(title: "Заголовок", width: 210)]
        public string Subject { get; set; }

        [Column(title: "Текст", gridViewAutoSize: GridViewAutoSize.Fill)]
        public string Body { get; set; }
    
        [Column(title: "Ответ", gridViewAutoSize: GridViewAutoSize.Fill)]
        public string Reply { get; set; }
    }
}
