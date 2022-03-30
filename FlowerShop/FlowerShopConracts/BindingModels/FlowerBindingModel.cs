using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace FlowerShopConracts.BindingModels
{
    /// Букет, собираемый в цветочной лавке
    [DataContract]
    public class FlowerBindingModel
    {
        [DataMember]
        public int? Id { get; set; }
        [DataMember]
        public string FlowerName { get; set; }
        [DataMember]
        public decimal Price { get; set; }
        [DataMember]
        public Dictionary<int, (string, int)> FlowerComponents { get; set; }
    }
}
