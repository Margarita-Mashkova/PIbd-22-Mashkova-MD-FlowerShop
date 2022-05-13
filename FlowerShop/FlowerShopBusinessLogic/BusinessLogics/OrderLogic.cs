using System;
using System.Collections.Generic;
using FlowerShopConracts.BindingModels;
using FlowerShopConracts.BusinessLogicsContracts;
using FlowerShopConracts.StoragesContracts;
using FlowerShopConracts.ViewModels;
using FlowerShopConracts.Enums;
using FlowerShopBusinessLogic.MailWorker;

namespace FlowerShopBusinessLogic.BusinessLogics
{
    public class OrderLogic : IOrderLogic
    {
        private readonly IOrderStorage _orderStorage;
        private readonly IClientStorage _clientStorage;
        private readonly AbstractMailWorker _abstractMailWorker;
        private readonly IStorehouseStorage _storehouseStorage;
        private readonly IFlowerStorage _flowerStorage;
        private readonly object locker = new object();
        public OrderLogic(IOrderStorage orderStorage, IClientStorage clientStorage, IStorehouseStorage storehouseStorage, IFlowerStorage flowerStorage, AbstractMailWorker abstractMailWorker)
        {
            _orderStorage = orderStorage;
            _clientStorage = clientStorage;
            _abstractMailWorker = abstractMailWorker;
            _storehouseStorage = storehouseStorage;
            _flowerStorage = flowerStorage;
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
            _abstractMailWorker.MailSendAsync(new MailSendInfoBindingModel
            {
                MailAddress = _clientStorage.GetElement(new ClientBindingModel
                {
                    Id = model.ClientId
                })?.Email,
                Subject = $"Новый заказ",
                Text = $"Заказ от {DateTime.Now} на сумму {model.Sum:N2} принят."
            });
        }
        public void TakeOrderInWork(ChangeStatusBindingModel model)
        {
            lock (locker)
            {
                OrderStatus status = OrderStatus.Выполняется;
                var order = _orderStorage.GetElement(new OrderBindingModel
                {
                    Id = model.OrderId
                });
                if (order == null)
                {
                    throw new Exception("Заказ не найден");
                }
                if (!order.Status.Equals("Принят") && !order.Status.Equals("Требуются_материалы"))
                {
                    throw new Exception($"Невозможно обработать заказ, т.к. он не имеет статуса {OrderStatus.Принят} или {OrderStatus.Требуются_материалы}");
                }
                var flower = _flowerStorage.GetElement(new FlowerBindingModel { Id = order.FlowerId });
                if (!_storehouseStorage.CheckAvailability(order.Count, flower.FlowerComponents))
                {
                    status = OrderStatus.Требуются_материалы;
                    model.ImplementerId = null;
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
                    Status = status
                });
            }
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
            if (order.Status.Equals("Требуются_материалы"))
            {
                return;
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
            _abstractMailWorker.MailSendAsync(new MailSendInfoBindingModel
            {
                MailAddress = _clientStorage.GetElement(new ClientBindingModel
                {
                    Id = order.ClientId
                })?.Email,
                Subject = $"Заказ №{order.Id}",
                Text = $"Заказ №{order.Id} готов."
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
            _abstractMailWorker.MailSendAsync(new MailSendInfoBindingModel
            {
                MailAddress = _clientStorage.GetElement(new ClientBindingModel
                {
                    Id = order.ClientId
                })?.Email,
                Subject = $"Заказ №{order.Id}",
                Text = $"Заказ №{order.Id} выдан."
            });
        }
    }
}
