using FlowerShopConracts.BindingModels;
using FlowerShopConracts.BusinessLogicsContracts;
using FlowerShopConracts.StoragesContracts;
using FlowerShopConracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowerShopBusinessLogic.BusinessLogics
{
    public class MessageInfoLogic : IMessageInfoLogic
    {
        private readonly IMessageInfoStorage _messageInfoStorage;
        public MessageInfoLogic(IMessageInfoStorage messageInfoStorage)
        {
            _messageInfoStorage = messageInfoStorage;
        }
        public List<MessageInfoViewModel> Read(MessageInfoBindingModel model)
        {
            if (model == null)
            {
                return _messageInfoStorage.GetFullList();
            }
            return _messageInfoStorage.GetFilteredList(model);
        }
        //TODO: update
        public void CreateOrUpdate(MessageInfoBindingModel model)
        {
            if (model.IsRead == false || !string.IsNullOrEmpty(model.Reply))
            {
                _messageInfoStorage.Update(model);
            }
            else
            {
                _messageInfoStorage.Insert(model);
            }
        }
    }
}
