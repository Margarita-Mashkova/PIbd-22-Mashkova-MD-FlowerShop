﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using FlowerShopConracts.Attributes;

namespace FlowerShopConracts.ViewModels
{
    /// Букет, собираемый в цветочной лавке
    public class FlowerViewModel
    {
        [Column(title: "Номер", width: 80)]
        public int Id { get; set; }

        [Column(title: "Название букета", width: 180)]
        public string FlowerName { get; set; }

        [Column(title: "Цена", width: 60)]
        public decimal Price { get; set; }

        [Column(title: "Компоненты", gridViewAutoSize: GridViewAutoSize.Fill)]
        public Dictionary<int, (string, int)> FlowerComponents { get; set; }
        public string GetComponents()
        {
            string stringComponents = string.Empty;
            if (FlowerComponents != null)
            {
                foreach (var component in FlowerComponents)
                {
                    stringComponents += component.Value.Item1 + " = " + component.Value.Item2 + " шт.; ";
                }
            }
            return stringComponents;
        }
    }
}
