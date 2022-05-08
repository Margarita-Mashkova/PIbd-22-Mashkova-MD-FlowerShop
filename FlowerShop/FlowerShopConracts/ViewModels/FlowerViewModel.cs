using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using FlowerShopConracts.Attributes;

namespace FlowerShopConracts.ViewModels
{
    /// Букет, собираемый в цветочной лавке
    public class FlowerViewModel
    {
        [Column(title: "Номер", width: 100)]
        public int Id { get; set; }

        [Column(title: "Название букета", gridViewAutoSize: GridViewAutoSize.Fill)]
        //[DisplayName("Название букета")]
        public string FlowerName { get; set; }

        [Column(title: "Цена", width: 100)]
        //[DisplayName("Цена")]
        public decimal Price { get; set; }

        [Column(title: "Компоненты", gridViewAutoSize: GridViewAutoSize.Fill)]
        public Dictionary<int, (string, int)> FlowerComponents { get; set; }
    }
}
