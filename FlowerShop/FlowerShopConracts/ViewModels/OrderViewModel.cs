﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using FlowerShopConracts.Enums;

namespace FlowerShopConracts.ViewModels
{
    /// Заказ
    public class OrderViewModel
    {
        public int Id { get; set; }
        public int FlowerId { get; set; }

        [DisplayName("Букет")]
        public string FlowerName { get; set; }

        [DisplayName("Количество")]
        public int Count { get; set; }

        [DisplayName("Сумма")]
        public decimal Sum { get; set; }

        [DisplayName("Статус")]
        public string Status { get; set; } 

        [DisplayName("Дата создания")]
        public DateTime DateCreate { get; set; }

        [DisplayName("Дата выполнения")]
        public DateTime? DateImplement { get; set; }
    }
}
