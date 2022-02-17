using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using FlowerShopConracts.BindingModels;
using FlowerShopConracts.ViewModels;

namespace FlowerShopConracts.BusinessLogicsContracts
{
    public interface IFlowerLogic
    {
        List<FlowerViewModel> Read(FlowerBindingModel model);
        void CreateOrUpdate(FlowerBindingModel model);
        void Delete(FlowerBindingModel model);
    }
}
