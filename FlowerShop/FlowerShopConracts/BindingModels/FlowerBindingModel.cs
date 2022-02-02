using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowerShopConracts.BindingModels
{
    /// Изделие (букеты), изготавливаемое в цветочной лавке
    public class FlowerBindingModel
    {
        public int? Id { get; set; }
        public string FlowerName { get; set; }
        public decimal Price { get; set; }
        public Dictionary<int, (string, int)> FlowerComponents { get; set; }
    }
}
