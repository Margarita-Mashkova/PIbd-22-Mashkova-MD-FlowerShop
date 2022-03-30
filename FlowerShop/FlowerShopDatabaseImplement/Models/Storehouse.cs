using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlowerShopDatabaseImplement.Models
{
	public class Storehouse
	{
        public int Id { get; set; }

        [Required]
        public string StorehouseName { get; set; }

        [Required]
        public string ResponsibleFullName { get; set; }

        [Required]
        public DateTime DateCreate { get; set; }

        [ForeignKey("StorehouseId")]
        public virtual List<StorehouseComponent> StorehouseComponents { get; set; }
    }
}
