using FlowerShopConracts.BindingModels;
using FlowerShopConracts.ViewModels;
using FlowerShopStorehouseApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FlowerShopStorehouseApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            if (Program.Enter == null)
            {
                return Redirect("~/Home/Enter");
            }
            return View(APIStorehouse.GetRequest<List<StorehouseViewModel>>("api/storehouse/GetStorehouseList"));
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public IActionResult Enter()
        {
            return View();
        }

        [HttpPost]
        public void Enter(string password)
        {
            if (!string.IsNullOrEmpty(password))
            {
                if (password != Program.Password)
                {
                    throw new Exception("Неверный пароль");
                }
                Program.Enter = true;
                Response.Redirect("Index");
                return;
            }
            throw new Exception("Введите логин, пароль");
        }

        [HttpPost]
        public void Create(string storehouseName, string FIO)
        {
            if (!string.IsNullOrEmpty(storehouseName) && !string.IsNullOrEmpty(FIO))
            {
                APIStorehouse.PostRequest("api/storehouse/CreateOrUpdateStorehouse", new StorehouseBindingModel
                {
                    ResponsibleFullName = FIO,
                    StorehouseName = storehouseName,
                    DateCreate = DateTime.Now,
                    StorehouseComponents = new Dictionary<int, (string, int)>()
                });
                Response.Redirect("Index");
                return;
            }
            throw new Exception("Введите имя и ответственного");
        }

        [HttpGet]
        public IActionResult Update(int storehouseId)
        {
            var storehouse = APIStorehouse.GetRequest<StorehouseViewModel>($"api/storehouse/GetStorehouse?storehouseId={storehouseId}");
            ViewBag.StorehouseComponents = storehouse.StorehouseComponents.Values;
            ViewBag.StorehouseName = storehouse.StorehouseName;
            ViewBag.FIO = storehouse.ResponsibleFullName;
            return View();
        }

        [HttpPost]
        public void Update(int storehouseId, string storehouseName, string FIO)
        {
            if (!string.IsNullOrEmpty(storehouseName) && !string.IsNullOrEmpty(FIO))
            {
                var storehouse = APIStorehouse.GetRequest<StorehouseViewModel>($"api/storehouse/GetStorehouse?storehouseId={storehouseId}");
                if (storehouse == null)
                {
                    return;
                }
                APIStorehouse.PostRequest("api/storehouse/CreateOrUpdateStorehouse", new StorehouseBindingModel
                {
                    ResponsibleFullName = FIO,
                    StorehouseName = storehouseName,
                    DateCreate = DateTime.Now,
                    StorehouseComponents = storehouse.StorehouseComponents,
                    Id = storehouse.Id
                });
                Response.Redirect("Index");
                return;
            }
            throw new Exception("Введите логин, пароль и ФИО");
        }

        [HttpGet]
        public IActionResult Delete()
        {
            if (Program.Enter == null)
            {
                return Redirect("~/Home/Enter");
            }
            ViewBag.Storehouse = APIStorehouse.GetRequest<List<StorehouseViewModel>>("api/storehouse/GetStorehouseList");
            return View();
        }

        [HttpPost]
        public void Delete(int storehouseId)
        {
            APIStorehouse.PostRequest("api/storehouse/DeleteStorehouse", new StorehouseBindingModel
            {
                Id = storehouseId
            });
            Response.Redirect("Index");
        }

        [HttpGet]
        public IActionResult AddComponent()
        {
            if (Program.Enter == null)
            {
                return Redirect("~/Home/Enter");
            }
            ViewBag.Storehouse = APIStorehouse.GetRequest<List<StorehouseViewModel>>("api/storehouse/GetStorehouseList");
            ViewBag.Component = APIStorehouse.GetRequest<List<ComponentViewModel>>("api/storehouse/GetComponents");
            return View();
        }

        [HttpPost]
        public void AddComponent(int storehouseId, int componentId, int count)
        {
            APIStorehouse.PostRequest("api/storehouse/AddComponent", new AddComponentBindingModel
            {
                Id = storehouseId,
                ComponentId = componentId,
                Count = count
            });
            Response.Redirect("Index");
        }
    }
}