using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace FlowerShopConracts.ViewModels
{
    /// Букет, собираемый в цветочной лавке
    public class FlowerViewModel
    {
        public int Id { get; set; }

        [DisplayName("Название букета")]
        public string FlowerName { get; set; }

        [DisplayName("Цена")]
        public decimal Price { get; set; }
        public Dictionary<int, (string, int)> FlowerComponents { get; set; }
    }
}
