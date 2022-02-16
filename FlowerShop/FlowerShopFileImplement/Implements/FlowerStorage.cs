﻿using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using FlowerShopConracts.BindingModels;
using FlowerShopConracts.StoragesContracts;
using FlowerShopConracts.ViewModels;
using FlowerShopFileImplement.Models;

namespace FlowerShopFileImplement.Implements
{
    public class FlowerStorage : IFlowerStorage
    {
        private readonly FileDataListSingleton source;
        public FlowerStorage()
        {
            source = FileDataListSingleton.GetInstance();
        }
        public List<FlowerViewModel> GetFullList()
        {
            return source.Flowers.Select(CreateModel).ToList();
        }
        public List<FlowerViewModel> GetFilteredList(FlowerBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            return source.Flowers.Where(rec => rec.FlowerName.Contains(model.FlowerName)).Select(CreateModel).ToList();
        }
        public FlowerViewModel GetElement(FlowerBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            var flower = source.Flowers.FirstOrDefault(rec => rec.FlowerName == model.FlowerName || rec.Id == model.Id);
            return flower != null ? CreateModel(flower) : null;
        }
        public void Insert(FlowerBindingModel model)
        {
            int maxId = source.Flowers.Count > 0 ? source.Components.Max(rec => rec.Id) : 0;
            var element = new Flower
            {
                Id = maxId + 1,
                FlowerComponents = new Dictionary<int, int>()
            };
            source.Flowers.Add(CreateModel(model, element));
        }
        public void Update(FlowerBindingModel model)
        {
            var element = source.Flowers.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            CreateModel(model, element);
        }
        public void Delete(FlowerBindingModel model)
        {
            Flower element = source.Flowers.FirstOrDefault(rec => rec.Id == model.Id);
            if (element != null)
            {
                source.Flowers.Remove(element);
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
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
            return new FlowerViewModel
            {
                Id = flower.Id,
                FlowerName = flower.FlowerName,
                Price = flower.Price,
                FlowerComponents = flower.FlowerComponents.ToDictionary(recFC => recFC.Key, recFC =>
                (source.Components.FirstOrDefault(recC => recC.Id == recFC.Key)?.ComponentName, recFC.Value))
            };
        }
    }
}
