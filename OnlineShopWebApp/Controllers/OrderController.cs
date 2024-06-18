using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Enums;
using OnlineShopWebApp.Interfaces;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
{
    public class OrderController : Controller
    {
        private readonly ICartsRepository _cartsRepository;
        private readonly IOrdersRepository _ordersRepository;
        private readonly IUsersRepository _usersRepository;

        public OrderController(ICartsRepository cartsRepository, IOrdersRepository ordersRepository, IUsersRepository usersRepository)
        {
            _cartsRepository = cartsRepository;
            _ordersRepository = ordersRepository;
            _usersRepository = usersRepository;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Buy(UserDeliveryInfo userDeliveryInfo)
        {
            if (ModelState.IsValid)
            {
                var cart = _cartsRepository.GetCart(_usersRepository.CurrentUserId);
                var order = new Order();
                order.DeliveryInfo = userDeliveryInfo;
                order.CartSum = cart.CostAllItems;
                _ordersRepository.AddOrder(order);
                _cartsRepository.ClearCart(_usersRepository.CurrentUserId);
                return View();
            }

            return View("Index");
        }
    }
}
