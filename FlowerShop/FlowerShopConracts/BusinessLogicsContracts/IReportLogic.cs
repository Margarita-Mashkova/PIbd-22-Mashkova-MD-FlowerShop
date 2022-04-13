using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlowerShopConracts.BindingModels;
using FlowerShopConracts.ViewModels;

namespace FlowerShopConracts.BusinessLogicsContracts
{
    public interface IReportLogic
    {
        // Получение списка компонент с указанием, в каких изделиях используются
        List<ReportFlowerComponentViewModel> GetFlowerComponent();

        // Получение списка компонент с указанием, на каких складах хранятся
        List<ReportStorehouseComponentViewModel> GetStorehouseComponent();

        // Получение списка заказов за определенный период
        List<ReportOrdersViewModel> GetOrders(ReportBindingModel model);

        // Сохранение букетов в файл-Word
        void SaveFlowersToWordFile(ReportBindingModel model);

        // Сохранение складов в файл-Word в табличном виде
        void SaveStorehousesToWordFile(ReportBindingModel model);

        // Сохранение компонент с указаеним букетов в файл-Excel
        void SaveFlowerComponentToExcelFile(ReportBindingModel model);

        // Сохранение компонент с указаеним складов в файл-Excel
        void SaveStorehouseComponentToExcelFile(ReportBindingModel model);

        // Сохранение заказов в файл-Pdf
        void SaveOrdersToPdfFile(ReportBindingModel model);
    }
}
