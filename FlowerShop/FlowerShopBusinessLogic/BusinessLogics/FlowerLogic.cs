using System;
using System.Collections.Generic;
using FlowerShopConracts.BindingModels;
using FlowerShopConracts.BusinessLogicsContracts;
using FlowerShopConracts.StoragesContracts;
using FlowerShopConracts.ViewModels;
using FlowerShopConracts.Enums;

namespace FlowerShopBusinessLogic.BusinessLogics
{
    public class FlowerLogic : IFlowerLogic
    {
        private readonly IFlowerStorage _flowerStorage;
        public FlowerLogic(IFlowerStorage flowerStorage)
        {
            _flowerStorage = flowerStorage;
        }
        public List<FlowerViewModel> Read(FlowerBindingModel model)
        {
            if (model == null)
            {
                return _flowerStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<FlowerViewModel> { _flowerStorage.GetElement(model) };
            }
            return _flowerStorage.GetFilteredList(model);
        }
        public void CreateOrUpdate(FlowerBindingModel model)
        {
            var element = _flowerStorage.GetElement(new FlowerBindingModel
            {
                FlowerName = model.FlowerName
            });
            if (element != null && element.Id != model.Id)
            {
                throw new Exception("Уже есть букет с таким названием");
            }
            if (model.Id.HasValue)
            {
                _flowerStorage.Update(model);
            }
            else
            {
                _flowerStorage.Insert(model);
            }
        }
        public void Delete(FlowerBindingModel model)
        {
            var element = _flowerStorage.GetElement(new FlowerBindingModel
            {
                Id = model.Id
            });
            if (element == null)
            {
                throw new Exception("Удаляемый элемент не найден");
            }
            _flowerStorage.Delete(model);
        }
    }
}
