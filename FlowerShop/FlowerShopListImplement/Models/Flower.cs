using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowerShopListImplement.Models
{
    public class Flower
    {
        public int Id { get; set; }
        public string FlowerName { get; set; }
        public decimal Price { get; set; }
        public Dictionary<int, int> FlowerComponents { get; set; }
    }
}
