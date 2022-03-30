using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlowerShopConracts.StoragesContracts;
using FlowerShopConracts.ViewModels;
using FlowerShopConracts.BindingModels;
using FlowerShopDatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;
using FlowerShopDatabaseImplement;

namespace FlowerShopDatabaseImplement.Implements
{
	public class StorehouseStorage : IStorehouseStorage
	{
        public List<StorehouseViewModel> GetFullList()
        {
            using var context = new FlowerShopDatabase();
            return context.Storehouses
            .Include(rec => rec.StorehouseComponents)
            .ThenInclude(rec => rec.Component)
            .ToList()
            .Select(CreateModel)
            .ToList();
        }
        public List<StorehouseViewModel> GetFilteredList(StorehouseBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using var context = new FlowerShopDatabase();
            return context.Storehouses
            .Include(rec => rec.StorehouseComponents)
            .ThenInclude(rec => rec.Component)
            .Where(rec => rec.StorehouseName.Contains(model.StorehouseName))
            .ToList()
            .Select(CreateModel)
            .ToList();
        }
        public StorehouseViewModel GetElement(StorehouseBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using var context = new FlowerShopDatabase();
            var storehouse = context.Storehouses
            .Include(rec => rec.StorehouseComponents)
            .ThenInclude(rec => rec.Component)
            .FirstOrDefault(rec => rec.StorehouseName == model.StorehouseName || rec.Id == model.Id);
            return storehouse != null ? CreateModel(storehouse) : null;
        }
        public void Insert(StorehouseBindingModel model)
        {
            using var context = new FlowerShopDatabase();
            using var transaction = context.Database.BeginTransaction();
            try
            {
                Storehouse storehouse = new Storehouse()
                {
                    StorehouseName = model.StorehouseName,
                    ResponsibleFullName = model.ResponsibleFullName,
                    DateCreate = model.DateCreate
                };
                context.Storehouses.Add(storehouse);
                context.SaveChanges();
                CreateModel(model, storehouse, context);
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }
        public void Update(StorehouseBindingModel model)
        {
            using var context = new FlowerShopDatabase();
            using var transaction = context.Database.BeginTransaction();
            try
            {
                var element = context.Storehouses.FirstOrDefault(rec => rec.Id == model.Id);
                if (element == null)
                {
                    throw new Exception("Элемент не найден");
                }
                CreateModel(model, element, context);
                context.SaveChanges();
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }
        public void Delete(StorehouseBindingModel model)
        {
            using var context = new FlowerShopDatabase();
            Storehouse element = context.Storehouses.FirstOrDefault(rec => rec.Id == model.Id);
            if (element != null)
            {
                context.Storehouses.Remove(element);
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }
        public bool CheckAvailability(int count, Dictionary<int, (string, int)> flowerComponents)
        {
            using var context = new FlowerShopDatabase();
            using var transaction = context.Database.BeginTransaction();
            try
            {
                foreach (var fc in flowerComponents)
                {
                    int requiredCount = fc.Value.Item2 * count;
                    foreach (var storehouse in context.Storehouses.Include(rec => rec.StorehouseComponents))
                    {
                        int? availableCount = storehouse.StorehouseComponents.FirstOrDefault(rec => rec.ComponentId == fc.Key)?.Count;
                        if (availableCount == null) { continue; }
                        requiredCount -= (int)availableCount;
                        storehouse.StorehouseComponents.FirstOrDefault(rec => rec.ComponentId == fc.Key).Count = (requiredCount < 0) ? (int)availableCount - ((int)availableCount + requiredCount) : 0;
                    }
                    if (requiredCount > 0)
                    {
                        throw new Exception("На складах недостаточно компонентов");
                    }
                }
                context.SaveChanges();
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
            return true;            
        }
        private Storehouse CreateModel(StorehouseBindingModel model, Storehouse storehouse, FlowerShopDatabase context)
        {
            storehouse.StorehouseName = model.StorehouseName;
            storehouse.ResponsibleFullName = model.ResponsibleFullName;
            storehouse.DateCreate = model.DateCreate;
            if (model.Id.HasValue)
            {
                var storehouseComponents = context.StorehouseComponents.Where(rec => rec.StorehouseId == model.Id.Value).ToList();
                // удалили те, которых нет в модели
                context.StorehouseComponents.RemoveRange(storehouseComponents.Where(rec => !model.StorehouseComponents.ContainsKey(rec.ComponentId)).ToList());
                context.SaveChanges();
                // обновили количество у существующих записей
                foreach (var updateComponent in storehouseComponents)
                {
                    updateComponent.Count = model.StorehouseComponents[updateComponent.ComponentId].Item2;
                    model.StorehouseComponents.Remove(updateComponent.ComponentId);
                }
                context.SaveChanges();
            }
            foreach (var sc in model.StorehouseComponents)
            {
                context.StorehouseComponents.Add(new StorehouseComponent
                {
                    StorehouseId = storehouse.Id,
                    ComponentId = sc.Key,
                    Count = sc.Value.Item2,
                });
                context.SaveChanges();
            }
            return storehouse;
        }
        private static StorehouseViewModel CreateModel(Storehouse storehouse)
        {
            return new StorehouseViewModel
            {
                Id = storehouse.Id,
                StorehouseName = storehouse.StorehouseName,
                ResponsibleFullName = storehouse.ResponsibleFullName,
                DateCreate = storehouse.DateCreate,
                StorehouseComponents = storehouse.StorehouseComponents
                .ToDictionary(recSC => recSC.ComponentId, recSC => (recSC.Component?.ComponentName, recSC.Count))
            };
        }
    }
}
