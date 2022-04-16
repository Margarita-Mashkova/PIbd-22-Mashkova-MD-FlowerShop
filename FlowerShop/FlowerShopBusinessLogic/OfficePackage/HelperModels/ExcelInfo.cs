using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlowerShopBusinessLogic.OfficePackage.HelperEnums;
using FlowerShopConracts.ViewModels;

namespace FlowerShopBusinessLogic.OfficePackage.HelperModels
{
    public class ExcelInfo
    {
        public string FileName { get; set; }
        public string Title { get; set; }
        public ExcelReportType ReportType { get; set; }
        public List<ReportFlowerComponentViewModel> FlowerComponent { get; set; }
        public List<ReportStorehouseComponentViewModel> StorehouseComponent { get; set; }
    }
}
