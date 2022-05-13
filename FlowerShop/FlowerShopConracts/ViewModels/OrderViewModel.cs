using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using FlowerShopConracts.Enums;
using FlowerShopConracts.Attributes;

namespace FlowerShopConracts.ViewModels
{
    /// Заказ
    public class OrderViewModel
    {
        [Column(title: "Номер", width: 70)]
        public int Id { get; set; }
        public int FlowerId { get; set; }
        public int ClientId { get; set; }
        public int? ImplementerId { get; set; }

        [Column(title: "Клиент", width: 160)]
        public string ClientFIO { get; set; }

        [Column(title: "Букет", gridViewAutoSize: GridViewAutoSize.Fill)]
        public string FlowerName { get; set; }

        [Column(title: "Количество", width: 90)]
        public int Count { get; set; }

        [Column(title: "Сумма", width: 80)]
        public decimal Sum { get; set; }

        [Column(title: "Исполнитель", width: 160)]
        public string ImplementerFIO { get; set; }

        [Column(title: "Статус", width: 100)]
        public string Status { get; set; }

        [Column(title: "Дата создания", width: 150)]
        public DateTime DateCreate { get; set; }

        [Column(title: "Дата выполнения", width: 150)]
        public DateTime? DateImplement { get; set; }
    }
}
