using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlowerShopListImplement.Models;
using FlowerShopConracts.BindingModels;
using FlowerShopConracts.StoragesContracts;
using FlowerShopConracts.ViewModels;

namespace FlowerShopListImplement.Implements
{
    public class FlowerStorage : IFlowerStorage
    {
        private readonly DataListSingleton source;
        public FlowerStorage()
        {
            source = DataListSingleton.GetInstance();
        }
        public List<FlowerViewModel> GetFullList()
        {
            var result = new List<FlowerViewModel>();
            foreach (var component in source.Flowers)
            {
                result.Add(CreateModel(component));
            }
            return result;
        }
        public List<FlowerViewModel> GetFilteredList(FlowerBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            var result = new List<FlowerViewModel>();
            foreach (var flower in source.Flowers)
            {
                if (flower.FlowerName.Contains(model.FlowerName))
                {
                    result.Add(CreateModel(flower));
                }
            }
            return result;
        }
        public FlowerViewModel GetElement(FlowerBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            foreach (var flower in source.Flowers)
            {
                if (flower.Id == model.Id || flower.FlowerName == model.FlowerName)
                {
                    return CreateModel(flower);
                }
            }
            return null;
        }
        public void Insert(FlowerBindingModel model)
        {
            var tempFlower = new Flower
            {
                Id = 1,
                FlowerComponents = new Dictionary<int, int>()
            };
            foreach (var flower in source.Flowers)
            {
                if (flower.Id >= tempFlower.Id)
                {
                    tempFlower.Id = flower.Id + 1;
                }
            }
            source.Flowers.Add(CreateModel(model, tempFlower));
        }
        public void Update(FlowerBindingModel model)
        {
            Flower tempFlower = null;
            foreach (var flower in source.Flowers)
            {
                if (flower.Id == model.Id)
                {
                    tempFlower = flower;
                }
            }
            if (tempFlower == null)
            {
                throw new Exception("Элемент не найден");
            }
            CreateModel(model, tempFlower);
        }
        public void Delete(FlowerBindingModel model)
        {
            for (int i = 0; i < source.Flowers.Count; ++i)
            {
                if (source.Flowers[i].Id == model.Id)
                {
                    source.Flowers.RemoveAt(i);
                    return;
                }
            }
            throw new Exception("Элемент не найден");
        }
        private static Flower CreateModel(FlowerBindingModel model, Flower flower)
        {
            flower.FlowerName = model.FlowerName;
            flower.Price = model.Price;
            // удаляем убранные
            foreach (var key in flower.FlowerComponents.Keys.ToList())
            {
                if (!model.FlowerComponents.ContainsKey(key))
                {
                    flower.FlowerComponents.Remove(key);
                }
            }
            // обновляем существуюущие и добавляем новые
            foreach (var component in model.FlowerComponents)
            {
                if (flower.FlowerComponents.ContainsKey(component.Key))
                {
                    flower.FlowerComponents[component.Key] = model.FlowerComponents[component.Key].Item2;
                }
                else
                {
                    flower.FlowerComponents.Add(component.Key, model.FlowerComponents[component.Key].Item2);
                }
            }
            return flower;
        }
        private FlowerViewModel CreateModel(Flower flower)
        {
            // требуется дополнительно получить список компонентов для букета с их названиями и их количеством
            var flowerComponents = new Dictionary<int, (string, int)>();
            foreach (var fc in flower.FlowerComponents)
            {
                string componentName = string.Empty;
                foreach (var component in source.Components)
                {
                    if (fc.Key == component.Id)
                    {
                        componentName = component.ComponentName;
                        break;
                    }
                }
                flowerComponents.Add(fc.Key, (componentName, fc.Value));
            }
            return new FlowerViewModel
            {
                Id = flower.Id,
                FlowerName = flower.FlowerName,
                Price = flower.Price,
                FlowerComponents = flowerComponents
            };
        }
    }
}
