using OnlineShopWebApp.Interfaces;
using OnlineShopWebApp.Models;
using System.Security.Cryptography.X509Certificates;

namespace OnlineShopWebApp.Services
{
    public class OrdersRepository : IOrdersRepository
    {
        private List<Order> _orders = new List<Order>();

        public void AddOrder(Order order)
        {
            _orders.Add(order);
        }

        public List<Order> GetOrders()
        {
            return _orders;
        }

        public Order GetOrder(int id)
        {
            return _orders.Find(x => x.Id == id);
        }
    }
}
