﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlowerShopConracts.Enums;
using System.ComponentModel.DataAnnotations;

namespace FlowerShopDatabaseImplement.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int FlowerId { get; set; }
        public virtual Flower Flower { get; set; }

        [Required]
        public int Count { get; set; }

        [Required]
        public decimal Sum { get; set; }

        [Required]
        public OrderStatus Status { get; set; }

        [Required]
        public DateTime DateCreate { get; set; }
        public DateTime? DateImplement { get; set; }
    }
}
