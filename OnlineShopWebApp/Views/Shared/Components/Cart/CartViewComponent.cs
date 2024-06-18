using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Interfaces;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Views.Shared.Components.Cart
{
    public class CartViewComponent : ViewComponent
    {
        private readonly ICartsRepository _cartsRepository;
        private readonly IUsersRepository _usersRepository;
        

        public CartViewComponent(ICartsRepository cartService, IUsersRepository usersRepository)
        {
            _cartsRepository = cartService;
            _usersRepository = usersRepository;
        }

        public IViewComponentResult Invoke()
        {
            var cart = _cartsRepository.GetCart(_usersRepository.CurrentUserId);
            var productCounts = cart.QuantityAllItems;

            return View("Cart", productCounts);
        }
    }
}
