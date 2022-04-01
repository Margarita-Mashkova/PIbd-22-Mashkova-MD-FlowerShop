using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlowerShopDatabaseImplement.Models
{
    /// Компонент, требуемый для изготовления изделия
    public class Component
    {
        public int Id { get; set; }

        [Required]
        public string ComponentName { get; set; }

        [ForeignKey("ComponentId")]
        public virtual List<FlowerComponent> FlowerComponents { get; set; }

        [ForeignKey("ComponentId")]
        public virtual List<StorehouseComponent> StorehouseComponents { get; set; }
    }
}
