using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlowerShopBusinessLogic.OfficePackage.HelperEnums;
using FlowerShopConracts.ViewModels;

namespace FlowerShopBusinessLogic.OfficePackage.HelperModels
{
    public class WordInfo
    {
        public string FileName { get; set; }
        public string Title { get; set; }
        public WordReportType ReportType { get; set; }
        public List<FlowerViewModel> Flowers { get; set; }
        public List<StorehouseViewModel> Storehouses { get; set; }
    }
}
