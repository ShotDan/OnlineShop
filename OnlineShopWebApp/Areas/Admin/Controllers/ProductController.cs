using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShop.Db.Models;
using OnlineShopWebApp.Interfaces;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IProductsRepository _productsDbRepository;
        private readonly IModelMapper _modelMapper;

        public ProductController(IProductsRepository productsRepository, IModelMapper modelMapper)
        {
            _productsDbRepository = productsRepository;
            _modelMapper = modelMapper;
        }

        public IActionResult Products()
        {
            var dbProducts = _productsDbRepository.GetProducts();
            var viewProducts = new List<ProductViewModel>();

            foreach (var dbProduct in dbProducts)
            {

                var viewProduct = _modelMapper.MapToViewModel(dbProduct);

                viewProducts.Add(viewProduct);
            }

            return View(viewProducts);
        }

        [HttpGet]
        public IActionResult EditProductIndex(Guid id)
        {
            var dbProduct = _productsDbRepository.GetProduct(id);
            var viewProduct = _modelMapper.MapToViewModel(dbProduct);

            return View(viewProduct);
        }

        [HttpPost]
        public IActionResult EditProduct(ProductViewModel viewProduct)
        {
            if (!ModelState.IsValid)
            {
                return View("EditProductIndex");
            }

            var dbProduct = _modelMapper.MapToDbModel(viewProduct);

            _productsDbRepository.EditProduct(dbProduct);

            return RedirectToAction("Products");
        }

        [HttpGet]
        public IActionResult AddProductIndex()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddProduct(ProductViewModel viewProduct)
        {
            if (!ModelState.IsValid)
            {
                return View("AddProductIndex");
            }

            var dbProduct = _modelMapper.MapToDbModel(viewProduct);

            _productsDbRepository.AddProduct(dbProduct);
            return RedirectToAction("Products");

        }

        public IActionResult DelProduct(Guid id)
        {
            var dbProduct = _productsDbRepository.GetProduct(id);
            _productsDbRepository.DelProduct(dbProduct);
            return RedirectToAction("Products");
        }
    }
}
