using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowerShopConracts.BindingModels
{
    public class StorehouseBindingModel
    {
        public int? Id { get; set; }
        public string StorehouseName { get; set; }
        public string ResponsibleFullName { get; set; }
        public DateTime DateCreate { get; set; }
        public Dictionary<int, (string, int)> StorehouseComponents { get; set; }
    }
}
