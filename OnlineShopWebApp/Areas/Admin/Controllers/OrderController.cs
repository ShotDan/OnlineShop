using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Enums;
using OnlineShopWebApp.Interfaces;

namespace OnlineShopWebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class OrderController : Controller
    {
        private readonly IOrdersRepository _ordersRepository;

        public OrderController(IOrdersRepository ordersRepository)
        {
            _ordersRepository = ordersRepository;
        }

        public IActionResult Orders()
        {
            var orders = _ordersRepository.GetOrders();
            return View(orders);
        }

        public IActionResult GetOrder(int id)
        {
            var order = _ordersRepository.GetOrder(id);

            if (order == null)
            {
                return RedirectToAction("Orders");
            }

            return View(order);
        }

        [HttpPost]
        public IActionResult EditOrderStatus(int id, OrderStatus orderStatus)
        {
            var order = _ordersRepository.GetOrder(id);
            order.Status = orderStatus;
            return RedirectToAction("GetOrder");
        }
    }
}
