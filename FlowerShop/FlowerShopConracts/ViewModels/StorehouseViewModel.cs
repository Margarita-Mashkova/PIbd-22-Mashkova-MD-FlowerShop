using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace FlowerShopConracts.ViewModels
{
    public class StorehouseViewModel
    {
        public int StorehouseId { get; set; }

        [DisplayName("Склад")]
        public string StorehouseName { get; set; }

        [DisplayName("ФИО ответственного")]
        public string ResponsibleFullName { get; set; }

        [DisplayName("Дата создания")]
        public DateTime DateCreate { get; set; }
        public Dictionary<int, (string, int)> StorehouseComponents { get; set; }
    }
}
