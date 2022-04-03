﻿using System;
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

        // Получение списка заказов за определенный период
        List<ReportOrdersViewModel> GetOrders(ReportBindingModel model);

        // Сохранение компонент в файл-Word
        void SaveComponentsToWordFile(ReportBindingModel model);

        // Сохранение компонент с указаеним букетов в файл-Excel
        void SaveFlowerComponentToExcelFile(ReportBindingModel model);

        // Сохранение заказов в файл-Pdf
        void SaveOrdersToPdfFile(ReportBindingModel model);
    }
}
