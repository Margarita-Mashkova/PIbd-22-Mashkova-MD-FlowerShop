using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowerShopConracts.ViewModels
{
    public class ReportStorehouseComponentViewModel
    {
        public string StorehouseName { get; set; }
        public int TotalCount { get; set; }
        public List<Tuple<string, int>> Components { get; set; }
    }
}
