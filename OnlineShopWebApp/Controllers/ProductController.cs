using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShopWebApp.Interfaces;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductsRepository _productsDbRepository;
        private readonly IModelMapper _modelMapper;

        public ProductController(IProductsRepository productsRepository, IModelMapper modelMapper)
        {
            _productsDbRepository = productsRepository;
            _modelMapper = modelMapper;
        }

        public IActionResult Index(Guid id)
        {
            var dbProduct = _productsDbRepository.GetProduct(id);

            if (dbProduct == null)
                return RedirectToAction("Index", "Home");

            var viewProduct = _modelMapper.MapToViewModel(dbProduct);

            return View(viewProduct);
        }
    }
}
