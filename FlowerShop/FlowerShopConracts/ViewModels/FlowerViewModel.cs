using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace FlowerShopConracts.ViewModels
{
    /// Букет, собираемый в цветочной лавке
    [DataContract]
    public class FlowerViewModel
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        [DisplayName("Название букета")]
        public string FlowerName { get; set; }

        [DataMember]
        [DisplayName("Цена")]
        public decimal Price { get; set; }

        [DataMember]
        public Dictionary<int, (string, int)> FlowerComponents { get; set; }
    }
}
