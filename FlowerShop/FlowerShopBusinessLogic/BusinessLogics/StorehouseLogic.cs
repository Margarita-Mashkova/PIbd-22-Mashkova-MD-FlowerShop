using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlowerShopConracts.BindingModels;
using FlowerShopConracts.BusinessLogicsContracts;
using FlowerShopConracts.StoragesContracts;
using FlowerShopConracts.ViewModels;

namespace FlowerShopBusinessLogic.BusinessLogics
{
    public class StorehouseLogic : IStorehouseLogic
    {
        private readonly IStorehouseStorage _storehouseStorage;
        private readonly IComponentStorage _componentStorage;
        public StorehouseLogic(IStorehouseStorage storehouseStorage)
        {
            _storehouseStorage = storehouseStorage;
        }
        public List<StorehouseViewModel> Read(StorehouseBindingModel model)
        {
            if (model == null)
            {
                return _storehouseStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<StorehouseViewModel> { _storehouseStorage.GetElement(model) };
            }
            return _storehouseStorage.GetFilteredList(model);
        }
        public void CreateOrUpdate(StorehouseBindingModel model)
        {
            var element = _storehouseStorage.GetElement(new StorehouseBindingModel
            {
                StorehouseName = model.StorehouseName,
                ResponsibleFullName = model.ResponsibleFullName,
                StorehouseComponents = model.StorehouseComponents
            });
            if (element != null && element.Id != model.Id)
            {
                throw new Exception("Уже есть склад с таким названием");
            }
            if (model.Id.HasValue)
            {
                _storehouseStorage.Update(model);
            }
            else
            {
                _storehouseStorage.Insert(model);
            }
        }
        public void Delete(StorehouseBindingModel model)
        {
            var element = _storehouseStorage.GetElement(new StorehouseBindingModel
            {
                Id = model.Id
            });
            if (element == null)
            {
                throw new Exception("Удаляемый элемент не найден");
            }
            _storehouseStorage.Delete(model);
        }
        //TODO: Доделать метод
        public void AddComponent(AddComponentBindingModel model)
        {
            var storehouse = _storehouseStorage.GetElement(new StorehouseBindingModel
            {
                Id = model.Id
            });
            var component = _componentStorage.GetElement(new ComponentBindingModel
            {
                Id = model.ComponentId
            });
            if (storehouse == null)
            {
                throw new Exception("Склад не найден");
            }
            if (component == null)
            {
                throw new Exception("Компонент не найден");
            }
            if (storehouse.StorehouseComponents.ContainsKey(model.ComponentId))
            {
                storehouse.StorehouseComponents[model.ComponentId] = (component.ComponentName, storehouse.StorehouseComponents[model.ComponentId].Item2 + model.Count);
            }
            else
            {
                storehouse.StorehouseComponents.Add(model.ComponentId, (component.ComponentName, model.Count));
            }
            _storehouseStorage.Update(new StorehouseBindingModel
            {
                Id = storehouse.Id,
                StorehouseName = storehouse.StorehouseName,
                ResponsibleFullName = storehouse.ResponsibleFullName,
                DateCreate = storehouse.DateCreate,
                StorehouseComponents = storehouse.StorehouseComponents
            });
        }
    }
}
