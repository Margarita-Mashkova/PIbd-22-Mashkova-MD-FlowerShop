﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowerShopConracts.BindingModels
{
    /// Данные от клиента, для создания заказа
    public class CreateOrderBindingModel
    {
        public int FlowerId { get; set; }
        public int ClientId { get; set; }
        public int Count { get; set; }
        public decimal Sum { get; set; }
    }
}
