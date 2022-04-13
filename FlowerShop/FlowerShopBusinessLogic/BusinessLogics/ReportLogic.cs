using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlowerShopBusinessLogic.OfficePackage;
using FlowerShopBusinessLogic.OfficePackage.HelperModels;
using FlowerShopBusinessLogic.OfficePackage.HelperEnums;
using FlowerShopConracts.BindingModels;
using FlowerShopConracts.BusinessLogicsContracts;
using FlowerShopConracts.StoragesContracts;
using FlowerShopConracts.ViewModels;


namespace FlowerShopBusinessLogic.BusinessLogics
{
    public class ReportLogic : IReportLogic
    {
        private readonly IFlowerStorage _flowerStorage;
        private readonly IOrderStorage _orderStorage;
        private readonly IStorehouseStorage _storehouseStorage;
        private readonly AbstractSaveToExcel _saveToExcel;
        private readonly AbstractSaveToWord _saveToWord;
        private readonly AbstractSaveToPdf _saveToPdf;
        public ReportLogic(IFlowerStorage flowerStorage, IOrderStorage orderStorage, IStorehouseStorage storehouseStorage,
            AbstractSaveToExcel saveToExcel, AbstractSaveToWord saveToWord, AbstractSaveToPdf saveToPdf)
        {
            _flowerStorage = flowerStorage;
            _orderStorage = orderStorage;
            _storehouseStorage = storehouseStorage;
            _saveToExcel = saveToExcel;
            _saveToWord = saveToWord;
            _saveToPdf = saveToPdf;
        }

        // Получение списка компонент с указанием, в каких изделиях используются
        public List<ReportFlowerComponentViewModel> GetFlowerComponent()
        {
            var flowers = _flowerStorage.GetFullList();
            var list = new List<ReportFlowerComponentViewModel>();
            foreach (var flower in flowers)
            {
                var record = new ReportFlowerComponentViewModel
                {
                    FlowerName = flower.FlowerName,
                    Components = new List<Tuple<string, int>>(),
                    TotalCount = 0
                };
                foreach (var component in flower.FlowerComponents)
                {
                    record.Components.Add(new Tuple<string, int>(component.Value.Item1, component.Value.Item2));
                    record.TotalCount += component.Value.Item2;
                }
                list.Add(record);
            }
            return list;
        }

        // Получение списка компонент с указанием, на каких складах хранятся
        public List<ReportStorehouseComponentViewModel> GetStorehouseComponent()
        {
            var storehouses = _storehouseStorage.GetFullList();
            var list = new List<ReportStorehouseComponentViewModel>();
            foreach (var storehouse in storehouses)
            {
                var record = new ReportStorehouseComponentViewModel
                {
                    StorehouseName = storehouse.StorehouseName,
                    Components = new List<Tuple<string, int>>(),
                    TotalCount = 0
                };
                foreach (var component in storehouse.StorehouseComponents)
                {
                    record.Components.Add(new Tuple<string, int>(component.Value.Item1, component.Value.Item2));
                    record.TotalCount += component.Value.Item2;
                }
                list.Add(record);
            }
            return list;
        }

        // Получение списка заказов за определенный период
        public List<ReportOrdersViewModel> GetOrders(ReportBindingModel model)
        {
            return _orderStorage.GetFilteredList(new OrderBindingModel
            {
                DateFrom = model.DateFrom,
                DateTo = model.DateTo
            })
            .Select(x => new ReportOrdersViewModel
            {
                DateCreate = x.DateCreate,
                FlowerName = x.FlowerName,
                Count = x.Count,
                Sum = x.Sum,
                Status = x.Status
            })
           .ToList();
        }

        // Сохранение букетов в файл-Word
        public void SaveFlowersToWordFile(ReportBindingModel model)
        {
            _saveToWord.CreateDoc(new WordInfo
            {
                FileName = model.FileName,
                Title = "Список букетов",
                Flowers = _flowerStorage.GetFullList(),
                ReportType = WordReportType.ReportFlowers
            });
        }

        // Сохранение складов в файл-Word
        public void SaveStorehousesToWordFile(ReportBindingModel model)
        {
            _saveToWord.CreateDoc(new WordInfo
            {
                FileName = model.FileName,
                Title = "Таблица складов",
                Storehouses = _storehouseStorage.GetFullList(),
                ReportType = WordReportType.ReportStorhouses
            });
        }

        // Сохранение компонент с указанием продуктов в файл-Excel
        public void SaveFlowerComponentToExcelFile(ReportBindingModel model)
        {
            _saveToExcel.CreateReport(new ExcelInfo
            {
                FileName = model.FileName,
                Title = "Список компонент по букетам",
                FlowerComponent = GetFlowerComponent(),
                ReportType = ExcelReportType.FlowerComponents
            });
        }

        // Сохранение компонент с указанием продуктов в файл-Excel
        public void SaveStorehouseComponentToExcelFile(ReportBindingModel model)
        {
            _saveToExcel.CreateReport(new ExcelInfo
            {
                FileName = model.FileName,
                Title = "Список компонент по складам",
                StorehouseComponent = GetStorehouseComponent(),
                ReportType = ExcelReportType.StorehouseComponents
            });
        }

        // Сохранение заказов в файл-Pdf
        public void SaveOrdersToPdfFile(ReportBindingModel model)
        {
            _saveToPdf.CreateDoc(new PdfInfo
            {
                FileName = model.FileName,
                Title = "Список заказов",
                DateFrom = model.DateFrom.Value,
                DateTo = model.DateTo.Value,
                Orders = GetOrders(model)
            });
        }       
    }
}
