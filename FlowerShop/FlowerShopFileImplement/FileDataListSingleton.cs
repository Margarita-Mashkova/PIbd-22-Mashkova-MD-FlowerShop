﻿using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using FlowerShopFileImplement.Models;
using FlowerShopConracts.Enums;

namespace FlowerShopFileImplement
{
    public class FileDataListSingleton
    {
        private static FileDataListSingleton instance;
        private readonly string ComponentFileName = "Component.xml";
        private readonly string OrderFileName = "Order.xml";
        private readonly string FlowerFileName = "Flower.xml";
        public List<Component> Components { get; set; }
        public List<Order> Orders { get; set; }
        public List<Flower> Flowers { get; set; }
        private FileDataListSingleton()
        {
            Components = LoadComponents();
            Orders = LoadOrders();
            Flowers = LoadFlowers();
        }
        public static FileDataListSingleton GetInstance()
        {
            if (instance == null)
            {
                instance = new FileDataListSingleton();
            }
            return instance;
        }
        /*~FileDataListSingleton()
        {
            SaveComponents();
            SaveOrders();
            SaveFlowers();
        }*/
        public static void SaveData() 
        {
            instance.SaveComponents();
            instance.SaveOrders();
            instance.SaveFlowers();
        }
        private List<Component> LoadComponents()
        {
            var list = new List<Component>();
            if (File.Exists(ComponentFileName))
            {
                var xDocument = XDocument.Load(ComponentFileName);
                var xElements = xDocument.Root.Elements("Component").ToList();
                foreach (var elem in xElements)
                {
                    list.Add(new Component
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        ComponentName = elem.Element("ComponentName").Value
                    });
                }
            }
            return list;
        }
        private List<Order> LoadOrders()
        {
            var list = new List<Order>();
            if (File.Exists(OrderFileName)) 
            {
                var xDocument = XDocument.Load(OrderFileName);
                var xElements = xDocument.Root.Elements("Order").ToList();
                foreach (var elem in xElements) 
                {
                    list.Add(new Order
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        FlowerId = Convert.ToInt32(elem.Element("FlowerId").Value),
                        Count = Convert.ToInt32(elem.Element("Count").Value),
                        Sum = Convert.ToDecimal(elem.Element("Sum").Value),
                        Status = (OrderStatus)Enum.Parse(typeof(OrderStatus), elem.Element("Status").Value),
                        //DateCreate = Convert.ToDateTime(elem.Element("DateCreate").Value),
                        //DateImplement = Convert.ToDateTime(elem.Element("DateImplement").Value)
                    });
                    if (elem.Element("DateCreate").Value != "")
                        list.Last().DateCreate = DateTime.ParseExact(elem.Element("DateCreate").Value, "d.M.yyyy H:m:s", null);
                    if (elem.Element("DateImplement").Value != "")
                        list.Last().DateImplement = DateTime.ParseExact(elem.Element("DateImplement").Value, "d.M.yyyy H:m:s", null);
                }
            }
            return list;
        }
        private List<Flower> LoadFlowers()
        {
            var list = new List<Flower>();
            if (File.Exists(FlowerFileName))
            {
                var xDocument = XDocument.Load(FlowerFileName);
                var xElements = xDocument.Root.Elements("Flower").ToList();
                foreach (var elem in xElements)
                {
                    var flowerComp = new Dictionary<int, int>();
                    foreach (var component in elem.Element("FlowerComponents").Elements("FlowerComponent").ToList())
                    {
                        flowerComp.Add(Convert.ToInt32(component.Element("Key").Value), Convert.ToInt32(component.Element("Value").Value));
                    }
                    list.Add(new Flower
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        FlowerName = elem.Element("FlowerName").Value,
                        Price = Convert.ToDecimal(elem.Element("Price").Value),
                        FlowerComponents = flowerComp
                    });
                }
            }
            return list;
        }
        private void SaveComponents()
        {
            if (Components != null)
            {
                var xElement = new XElement("Components");
                foreach (var component in Components)
                {
                    xElement.Add(new XElement("Component",
                    new XAttribute("Id", component.Id),
                    new XElement("ComponentName", component.ComponentName)));
                }
                var xDocument = new XDocument(xElement); 
                xDocument.Save(ComponentFileName);
            }
        }
        private void SaveOrders()
        {
            if (Orders != null)
            {
                var xElement = new XElement("Orders");
                foreach (var order in Orders)
                {
                    xElement.Add(new XElement("Order",
                    new XAttribute("Id", order.Id),
                    new XElement("FlowerId", order.FlowerId),
                    new XElement("Count", order.Count),
                    new XElement("Sum", order.Sum),
                    new XElement("Status", order.Status),
                    new XElement("DateCreate", order.DateCreate.ToString()), //toString??
                    new XElement("DateImplement", order.DateImplement.ToString())));
                }
                var xDocument = new XDocument(xElement);
                xDocument.Save(OrderFileName);
            }
        }
        private void SaveFlowers()
        {
            if (Flowers != null)
            {
                var xElement = new XElement("Flowers");
                foreach (var flower in Flowers)
                {
                    var compElement = new XElement("FlowerComponents");
                    foreach (var component in flower.FlowerComponents)
                    {
                        compElement.Add(new XElement("FlowerComponent",
                        new XElement("Key", component.Key),
                        new XElement("Value", component.Value)));
                    }
                    xElement.Add(new XElement("Flower",
                     new XAttribute("Id", flower.Id),
                     new XElement("ProductName", flower.FlowerName),
                     new XElement("Price", flower.Price),
                     compElement));
                }
                var xDocument = new XDocument(xElement);
                xDocument.Save(FlowerFileName);
            }
        }
    }
}
