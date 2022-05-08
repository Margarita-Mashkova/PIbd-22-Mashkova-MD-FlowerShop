using FlowerShopConracts.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowerShopConracts.ViewModels
{
    public class ImplementerViewModel
    {
        [Column(title: "Номер", width: 100)]
        public int Id { get; set; }

        [Column(title: "ФИО", gridViewAutoSize: GridViewAutoSize.Fill)]
        //[DisplayName("ФИО")]
        public string ImplementerFIO { get; set; }

        [Column(title: "Время на заказ", width: 100)]
        //[DisplayName("Время на заказ")]
        public int WorkingTime { get; set; }

        [Column(title: "Время на перерыв", width: 100)]
        //[DisplayName("Время на перерыв")]
        public int PauseTime { get; set; }
    }
}
