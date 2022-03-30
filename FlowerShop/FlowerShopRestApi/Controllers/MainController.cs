using FlowerShopConracts.BindingModels;
using FlowerShopConracts.BusinessLogicsContracts;
using FlowerShopConracts.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FlowerShopRestApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MainController : ControllerBase
    {
        private readonly IOrderLogic _order;
        private readonly IFlowerLogic _flower;
        public MainController(IOrderLogic order, IFlowerLogic flower)
        {
            _order = order;
            _flower = flower;
        }

        [HttpGet]
        public List<FlowerViewModel> GetFlowerList() => _flower.Read(null)?.ToList();

        [HttpGet]
        public FlowerViewModel GetFlower(int flowerId) => _flower.Read(new FlowerBindingModel { Id = flowerId })?[0];

        [HttpGet]
        public List<OrderViewModel> GetOrders(int clientId) => _order.Read(new OrderBindingModel { ClientId = clientId });

        [HttpPost]
        public void CreateOrder(CreateOrderBindingModel model) => _order.CreateOrder(model);
    }
}
