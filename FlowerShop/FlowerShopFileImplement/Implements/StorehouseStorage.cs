using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlowerShopFileImplement.Models;
using FlowerShopConracts.BindingModels;
using FlowerShopConracts.StoragesContracts;
using FlowerShopConracts.ViewModels;

namespace FlowerShopFileImplement.Implements
{
    public class StorehouseStorage : IStorehouseStorage
    {
        private readonly FileDataListSingleton source;
        public StorehouseStorage()
        {
            source = FileDataListSingleton.GetInstance();
        }
        public List<StorehouseViewModel> GetFullList()
        {
            return source.Storehouses.Select(CreateModel).ToList();
        }
        public List<StorehouseViewModel> GetFilteredList(StorehouseBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            return source.Storehouses.Where(rec => rec.StorehouseName.Contains(model.StorehouseName)).Select(CreateModel).ToList();
        }
        public StorehouseViewModel GetElement(StorehouseBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            var storehouse = source.Storehouses.FirstOrDefault(rec => rec.StorehouseName == model.StorehouseName || rec.Id == model.Id);
            return storehouse != null ? CreateModel(storehouse) : null;
        }
        public void Insert(StorehouseBindingModel model)
        {
            int maxId = source.Storehouses.Count > 0 ? source.Storehouses.Max(rec => rec.Id) : 0;
            var element = new Storehouse
            {
                Id = maxId + 1,
                StorehouseComponents = new Dictionary<int, int>()
            };
            source.Storehouses.Add(CreateModel(model, element));
        }
        public void Update(StorehouseBindingModel model)
        {
            var element = source.Storehouses.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            CreateModel(model, element);
        }
        public void Delete(StorehouseBindingModel model)
        {
            Storehouse element = source.Storehouses.FirstOrDefault(rec => rec.Id == model.Id);
            if (element != null)
            {
                source.Storehouses.Remove(element);
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }
        public bool CheckAvailability(int count, Dictionary<int, (string, int)> flowerComponents)
        {
            //проверяем на наличие необходимого количества компонентов
            foreach (var fc in flowerComponents)
            {
                //суммарное количество необходимого компонента для букета в заказе на всех складах
                int scCount = source.Storehouses
                    .Where(rec => rec.StorehouseComponents.ContainsKey(fc.Key))
                    .Sum(rec => rec.StorehouseComponents[fc.Key]);
                if (scCount < fc.Value.Item2 * count)
                {
                    return false;
                }
            }
            //забираем компоненты со складов
            foreach (var fc in flowerComponents)
            {
                int requiredCount = fc.Value.Item2 * count;
                while (requiredCount > 0)
                {
                    var storehouse = source.Storehouses
                        .FirstOrDefault(rec => rec.StorehouseComponents.ContainsKey(fc.Key) && rec.StorehouseComponents[fc.Key] > 0);
                    int availableCount = storehouse.StorehouseComponents[fc.Key];
                    requiredCount -= availableCount;
                    if (availableCount > requiredCount + availableCount)
                    {
                        storehouse.StorehouseComponents[fc.Key] = availableCount - (requiredCount + availableCount);
                    }
                    else 
                    {
                        storehouse.StorehouseComponents[fc.Key] = 0;
                    }
                }
            }
            return true;
        }
        private Storehouse CreateModel(StorehouseBindingModel model, Storehouse storehouse)
        {
            storehouse.StorehouseName = model.StorehouseName;
            storehouse.ResponsibleFullName = model.ResponsibleFullName;
            storehouse.DateCreate = model.DateCreate;
            // удаляем убранные
            foreach (var key in storehouse.StorehouseComponents.Keys.ToList())
            {
                if (!model.StorehouseComponents.ContainsKey(key))
                {
                    storehouse.StorehouseComponents.Remove(key);
                }
            }
            // обновляем существуюущие и добавляем новые
            foreach (var component in model.StorehouseComponents)
            {
                if (storehouse.StorehouseComponents.ContainsKey(component.Key))
                {
                    storehouse.StorehouseComponents[component.Key] = model.StorehouseComponents[component.Key].Item2;
                }
                else
                {
                    storehouse.StorehouseComponents.Add(component.Key, model.StorehouseComponents[component.Key].Item2);
                }
            }
            return storehouse;
        }
        private StorehouseViewModel CreateModel(Storehouse storehouse)
        {
            return new StorehouseViewModel
            {
                Id = storehouse.Id,
                StorehouseName = storehouse.StorehouseName,
                ResponsibleFullName = storehouse.ResponsibleFullName,
                DateCreate = storehouse.DateCreate,
                StorehouseComponents = storehouse.StorehouseComponents.ToDictionary(recSC => recSC.Key, recSC =>
                (source.Components.FirstOrDefault(recC => recC.Id == recSC.Key)?.ComponentName, recSC.Value))
            };
        }
    }
}
