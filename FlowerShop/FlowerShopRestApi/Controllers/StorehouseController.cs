using FlowerShopConracts.BindingModels;
using FlowerShopConracts.BusinessLogicsContracts;
using FlowerShopConracts.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FlowerShopRestApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StorehouseController : ControllerBase
    {
        private readonly IStorehouseLogic _logicS;
        private readonly IComponentLogic _logicC;
        public StorehouseController(IStorehouseLogic logicS, IComponentLogic logicC)
        {
            _logicS = logicS;
            _logicC = logicC;
        }

        [HttpGet]
        public List<StorehouseViewModel> GetStorehouseList() => _logicS.Read(null)?.ToList();

        [HttpGet]
        public StorehouseViewModel GetStorehouse(int storehouseId) => _logicS.Read(new StorehouseBindingModel { Id = storehouseId })?[0];

        [HttpPost]
        public void CreateOrUpdateStorehouse(StorehouseBindingModel model) => _logicS.CreateOrUpdate(model);

        [HttpPost]
        public void DeleteStorehouse(StorehouseBindingModel model) => _logicS.Delete(model);

        [HttpPost]
        public void AddComponent(AddComponentBindingModel model) => _logicS.AddComponent(model);

        [HttpGet]
        public List<ComponentViewModel> GetComponents() => _logicC.Read(null);
    }
}
