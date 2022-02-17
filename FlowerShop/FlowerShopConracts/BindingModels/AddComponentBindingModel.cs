using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowerShopConracts.BindingModels
{
    public class AddComponentBindingModel
    {
        public int Id { get; set; }
        public int ComponentId { get; set; }
        public int Count { get; set; }
    }
}
