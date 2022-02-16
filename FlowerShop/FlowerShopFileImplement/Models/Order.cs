using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using FlowerShopConracts.Enums;

namespace FlowerShopListImplement.Models
{
    /// Заказ
    public class Order
    {
        public int Id { get; set; }
        public int FlowerId { get; set; }
        public int Count { get; set; }
        public decimal Sum { get; set; }
        public OrderStatus Status { get; set; }
        public DateTime DateCreate { get; set; }
        public DateTime? DateImplement { get; set; }
    }
}
