using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using FlowerShopConracts.Attributes;

namespace FlowerShopConracts.ViewModels
{
    public class StorehouseViewModel
    {
        [Column(title: "Номер", width: 75)]
        public int Id { get; set; }

        [Column(title: "Наименование склада", width: 150)]
        public string StorehouseName { get; set; }

        [Column(title: "ФИО ответственного", width: 120)]
        public string ResponsibleFullName { get; set; }

        [Column(title: "Дата создания", width: 120)]
        public DateTime DateCreate { get; set; }

        [Column(title: "Компоненты", gridViewAutoSize: GridViewAutoSize.Fill)]
        public Dictionary<int, (string, int)> StorehouseComponents { get; set; }
    }
}
