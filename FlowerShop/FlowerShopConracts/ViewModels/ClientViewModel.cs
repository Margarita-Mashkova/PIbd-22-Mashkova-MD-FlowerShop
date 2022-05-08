using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using FlowerShopConracts.Attributes;

namespace FlowerShopConracts.ViewModels
{
    public class ClientViewModel
    {
        [Column(title: "Номер", width: 100)]
        public int Id { get; set; }

        [Column(title: "ФИО", width: 150)]
        //[DisplayName("ФИО")]
        public string ClientFIO { get; set; }

        [Column(title: "Логин", width: 150)]
        //[DisplayName("Логин")]
        public string Email { get; set; }

        [Column(title: "Пароль", width: 150)]
        //[DisplayName("Пароль")]
        public string Password { get; set; }
    }
}
