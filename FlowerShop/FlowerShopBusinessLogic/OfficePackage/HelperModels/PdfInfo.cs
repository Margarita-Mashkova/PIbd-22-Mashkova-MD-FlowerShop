using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlowerShopBusinessLogic.OfficePackage.HelperEnums;
using FlowerShopConracts.ViewModels;

namespace FlowerShopBusinessLogic.OfficePackage.HelperModels
{
    public class PdfInfo
    {
        public string FileName { get; set; }
        public string Title { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public PdfReportType ReportType { get; set; }
        public List<ReportOrdersViewModel> Orders { get; set; }
        public List<ReportOrdersByDateViewModel> OrdersByDate { get; set; }
    }
}
