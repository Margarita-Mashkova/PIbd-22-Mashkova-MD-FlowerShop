using System;
using System.Collections.Generic;
using FlowerShopConracts.BindingModels;
using FlowerShopConracts.BusinessLogicsContracts;
using FlowerShopConracts.StoragesContracts;
using FlowerShopConracts.ViewModels;
using FlowerShopConracts.Enums;

namespace FlowerShopBusinessLogic.BusinessLogics
{
    public class OrderLogic : IOrderLogic
    {
        private readonly IOrderStorage _orderStorage;
        public OrderLogic(IOrderStorage orderStorage)
        {
            _orderStorage = orderStorage;
        }
        public List<OrderViewModel> Read(OrderBindingModel model)
        {
            if (model == null)
            {
                return _orderStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<OrderViewModel> { _orderStorage.GetElement(model) };
            }
            return _orderStorage.GetFilteredList(model);
        }
        public void CreateOrder(CreateOrderBindingModel model)
        {
            _orderStorage.Insert(new OrderBindingModel
            {
                FlowerId = model.FlowerId,
                ClientId = model.ClientId,
                Count = model.Count,
                Sum = model.Sum,
                Status = FlowerShopConracts.Enums.OrderStatus.Принят,
                DateCreate = DateTime.Now
            });
        }
        public void TakeOrderInWork(ChangeStatusBindingModel model)
        {
            var order = _orderStorage.GetElement(new OrderBindingModel
            {
                Id = model.OrderId
            });
            if (order == null) 
            {
                throw new Exception("Заказ не найден");
            }
            if (!order.Status.Equals("Принят")) 
            {
                throw new Exception($"Невозможно обработать заказ, т.к. он не имеет статуса {OrderStatus.Принят}");
            }
            _orderStorage.Update(new OrderBindingModel 
            { 
                Id = order.Id,
                ClientId = order.ClientId,
                FlowerId = order.FlowerId,
                ImplementerId = model.ImplementerId,
                Sum = order.Sum,
                Count = order.Count,
                DateCreate = order.DateCreate,
                DateImplement = DateTime.Now,
                Status = OrderStatus.Выполняется                
            });
        }
        public void FinishOrder(ChangeStatusBindingModel model)
        {
            var order = _orderStorage.GetElement(new OrderBindingModel
            {
                Id = model.OrderId
            });
            if (order == null)
            {
                throw new Exception("Заказ не найден");
            }
            if (!order.Status.Equals("Выполняется")) 
            {
                throw new Exception($"Невозможно завершить заказ, т.к. он не имеет статуса {OrderStatus.Выполняется}");
            }
            _orderStorage.Update(new OrderBindingModel
            {
                Id = order.Id,
                FlowerId = order.FlowerId,
                ClientId = order.ClientId,
                ImplementerId = order.ImplementerId,
                Sum = order.Sum,
                Count = order.Count,
                DateCreate = order.DateCreate,
                DateImplement = DateTime.Now,
                Status = OrderStatus.Готов
            });
        }
        public void DeliveryOrder(ChangeStatusBindingModel model)
        {
            var order = _orderStorage.GetElement(new OrderBindingModel
            {
                Id = model.OrderId
            });
            if (order == null)
            {
                throw new Exception("Заказ не найден");
            }
            if (!order.Status.Equals("Готов"))
            {
                throw new Exception($"Невозможно выдать заказ, т.к. он не имеет статуса {OrderStatus.Готов}");
            }
            _orderStorage.Update(new OrderBindingModel
            {
                Id = order.Id,
                FlowerId = order.FlowerId,
                ClientId = order.ClientId,
                ImplementerId = order.ImplementerId,
                Sum = order.Sum,
                Count = order.Count,
                DateCreate = order.DateCreate,
                DateImplement = DateTime.Now,
                Status = OrderStatus.Выдан
            });
        }
    }
}
