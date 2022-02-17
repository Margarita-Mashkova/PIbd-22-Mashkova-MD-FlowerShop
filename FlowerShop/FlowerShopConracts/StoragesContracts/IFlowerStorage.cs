using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using FlowerShopConracts.BindingModels;
using FlowerShopConracts.ViewModels;

namespace FlowerShopConracts.StoragesContracts
{
    public interface IFlowerStorage
    {
        List<FlowerViewModel> GetFullList();
        List<FlowerViewModel> GetFilteredList(FlowerBindingModel model);
        FlowerViewModel GetElement(FlowerBindingModel model);
        void Insert(FlowerBindingModel model);
        void Update(FlowerBindingModel model);
        void Delete(FlowerBindingModel model);
    }
}
