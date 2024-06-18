using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Interfaces
{
    public interface IOrdersRepository
    {
        void AddOrder(Order order);
        List<Order> GetOrders();
        Order GetOrder(int id);
    }
}
