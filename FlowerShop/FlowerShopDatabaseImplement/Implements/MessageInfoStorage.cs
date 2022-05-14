using FlowerShopConracts.BindingModels;
using FlowerShopConracts.StoragesContracts;
using FlowerShopConracts.ViewModels;
using FlowerShopDatabaseImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowerShopDatabaseImplement.Implements
{
    public class MessageInfoStorage : IMessageInfoStorage
    {
        private readonly int stringsOnPage = 3;
        public List<MessageInfoViewModel> GetFullList()
        {
            using var context = new FlowerShopDatabase();
            return context.MessagesInfo
            .Select(CreateModel)
            .ToList();
        }
        public List<MessageInfoViewModel> GetFilteredList(MessageInfoBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using var context = new FlowerShopDatabase();
            var messages = context.MessagesInfo
            .Where(rec => (model.ClientId.HasValue && rec.ClientId == model.ClientId) ||
            (!model.ClientId.HasValue && rec.DateDelivery.Date == model.DateDelivery.Date) ||
            (!model.ClientId.HasValue && model.PageNumber.HasValue) ||
            (model.ClientId.HasValue && rec.ClientId == model.ClientId && model.PageNumber.HasValue));

            if (model.PageNumber.HasValue)
            {
                messages = messages.Skip(stringsOnPage * (model.PageNumber.Value - 1)).Take(stringsOnPage);
            }

            return messages.Select(CreateModel).ToList();
        }
        public void Insert(MessageInfoBindingModel model)
        {
            using var context = new FlowerShopDatabase();
            MessageInfo element = context.MessagesInfo.FirstOrDefault(rec => rec.MessageId == model.MessageId);
            if (element != null)
            {
                throw new Exception("Уже есть письмо с таким идентификатором");
            }
            context.MessagesInfo.Add(new MessageInfo
            {
                MessageId = model.MessageId,
                ClientId = model.ClientId,
                SenderName = model.FromMailAddress,
                DateDelivery = model.DateDelivery,
                Subject = model.Subject,
                Body = model.Body,
                IsRead = false
            });
            context.SaveChanges();
        }
        public void Update(MessageInfoBindingModel model)
        {
            using var context = new FlowerShopDatabase();
            using var transaction = context.Database.BeginTransaction();
            try
            {
                var element = context.MessagesInfo.FirstOrDefault(rec => rec.MessageId == model.MessageId);
                if (element == null)
                {
                    throw new Exception("Элемент не найден");
                }
                element.IsRead = true;
                if (!string.IsNullOrEmpty(model.Reply))
                {
                    element.Reply = model.Reply;
                }
                context.SaveChanges();
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }
        private MessageInfoViewModel CreateModel(MessageInfo message)
        {
            return new MessageInfoViewModel
            {
                MessageId = message.MessageId,
                SenderName = message.SenderName,
                DateDelivery = message.DateDelivery,
                Subject = message.Subject,
                Body = message.Body,
                IsRead = message.IsRead,
                Reply = message.Reply
            };
        }
    }
}
