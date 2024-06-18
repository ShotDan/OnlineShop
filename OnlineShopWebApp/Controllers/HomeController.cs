using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShop.Db.Models;
using OnlineShopWebApp.Interfaces;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductsRepository _productsDbRepository;
        private readonly IModelMapper _modelMapper;

        public HomeController(IProductsRepository productsRepository, IModelMapper modelMapper)
        {
            _productsDbRepository = productsRepository;
            _modelMapper = modelMapper;
        }

        public IActionResult Index()
        {
            ViewBag.LoggedInMessage = HttpContext.Session.GetString("LoggedInMessage");
            HttpContext.Session.Remove("LoggedInMessage");

            var dbProducts = _productsDbRepository.GetProducts();
            var viewProducts = new List<ProductViewModel>();

            foreach (var dbProduct in dbProducts)
            {
                var viewProduct = _modelMapper.MapToViewModel(dbProduct);

                viewProducts.Add(viewProduct);
            }

            return View(viewProducts);
        }
    }
}
