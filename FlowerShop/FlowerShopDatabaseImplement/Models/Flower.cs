﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlowerShopDatabaseImplement.Models
{
    public class Flower
    {
        public int Id { get; set; }

        [Required]
        public string FlowerName { get; set; }

        [Required]
        public decimal Price { get; set; }

        [ForeignKey("FlowerId")]
        public virtual List<FlowerComponent> FlowerComponents { get; set; }

        [ForeignKey("FlowerId")]
        public virtual Order Order { get; set; }    
    }
}
