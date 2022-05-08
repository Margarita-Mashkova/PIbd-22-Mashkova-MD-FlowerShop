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
        [Column(title: "Номер", width: 100)]
        public int Id { get; set; }
        public int FlowerId { get; set; }
        public int ClientId { get; set; }
        public int? ImplementerId { get; set; }

        [Column(title: "Клиент", width: 150)]
        //[DisplayName("Клиент")]
        public string ClientFIO { get; set; }

        [Column(title: "Букет", gridViewAutoSize: GridViewAutoSize.Fill)]
        //[DisplayName("Букет")]
        public string FlowerName { get; set; }

        [Column(title: "Количество", width: 100)]
        //[DisplayName("Количество")]
        public int Count { get; set; }

        [Column(title: "Сумма", width: 50)]
        //[DisplayName("Сумма")]
        public decimal Sum { get; set; }

        [Column(title: "Исполнитель", width: 150)]
        //[DisplayName("Исполнитель")]
        public string ImplementerFIO { get; set; }

        [Column(title: "Статус", width: 100)]
        //[DisplayName("Статус")]
        public string Status { get; set; }

        [Column(title: "Дата создания", width: 100)]
        //[DisplayName("Дата создания")]
        public DateTime DateCreate { get; set; }

        [Column(title: "Дата выполнения", width: 100)]
        //[DisplayName("Дата выполнения")]
        public DateTime? DateImplement { get; set; }
    }
}
