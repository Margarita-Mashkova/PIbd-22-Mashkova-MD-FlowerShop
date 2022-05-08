using FlowerShopConracts.BindingModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowerShopConracts.BusinessLogicsContracts
{
    public interface IBackUpLogic
    {
        void CreateBackUp(BackUpSaveBinidngModel model);
    }
}
