using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShopWebApp.Interfaces;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartsRepository _cartsRepository;
        private readonly IProductsRepository _productsDbRepository;
        private readonly IUsersRepository _usersRepository;
        private readonly IModelMapper _modelMapper;

        public CartController(ICartsRepository cartsRepository, IProductsRepository productsRepository, IUsersRepository usersRepository, IModelMapper modelMapper)
        {
            _cartsRepository = cartsRepository;
            _productsDbRepository = productsRepository;
            _usersRepository = usersRepository;
            _modelMapper = modelMapper;
        }


        public IActionResult Index()
        {
            var cart = _cartsRepository.GetCart(_usersRepository.CurrentUserId);
            return View(cart);
        }

        public IActionResult AddToCart(Guid productId)
        {
            var dbProduct = _productsDbRepository.GetProduct(productId);
            var viewProduct = _modelMapper.MapToViewModel(dbProduct);

            _cartsRepository.AddItemInCart(_usersRepository.CurrentUserId, viewProduct);
            return RedirectToAction("Index");
        }

        public IActionResult IncreaseQuantity(int itemId)
        {
            _cartsRepository.IncreaseQuantityItem(_usersRepository.CurrentUserId, itemId);
            return RedirectToAction("Index");
        }

        public IActionResult ReduceQuantity(int itemId)
        {
            _cartsRepository.ReduceQuantityItem(_usersRepository.CurrentUserId, itemId);
            return RedirectToAction("Index");
        }

        public IActionResult Clear()
        {
            _cartsRepository.ClearCart(_usersRepository.CurrentUserId);
            return RedirectToAction("Index");
        }
    }
}
