using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace FlowerShopConracts.BindingModels
{
    /// Данные от клиента, для создания заказа
    [DataContract]
    public class CreateOrderBindingModel
    {
        [DataMember]
        public int FlowerId { get; set; }
        [DataMember]
        public int Count { get; set; }
        [DataMember]
        public decimal Sum { get; set; }
    }
}
