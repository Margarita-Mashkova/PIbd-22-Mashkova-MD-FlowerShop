using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlowerShopConracts.BindingModels;
using FlowerShopConracts.ViewModels;

namespace FlowerShopConracts.BusinessLogicsContracts
{
    public interface IStorehouseLogic
    {
        List<StorehouseViewModel> Read(StorehouseBindingModel model);
        void CreateOrUpdate(StorehouseBindingModel model);
        void Delete(StorehouseBindingModel model);
        void AddComponent(AddComponentBindingModel model);
    }
}
