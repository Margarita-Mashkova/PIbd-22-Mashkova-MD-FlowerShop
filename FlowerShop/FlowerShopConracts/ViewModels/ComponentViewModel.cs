using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using FlowerShopConracts.Attributes;

namespace FlowerShopConracts.ViewModels
{
    /// Компонент, требуемый для изготовления букета
    public class ComponentViewModel
    {
        [Column(title: "Номер", width: 80)]
        public int Id { get; set; }

        [Column(title: "Название компонента", gridViewAutoSize: GridViewAutoSize.Fill)]
        public string ComponentName { get; set; }
    }
}
