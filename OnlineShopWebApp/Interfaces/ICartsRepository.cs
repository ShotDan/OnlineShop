using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Interfaces
{
    public interface ICartsRepository
    {
        void AddItemInCart(int userId, ProductViewModel product);
        Cart? GetCart(int userId);
        void IncreaseQuantityItem(int userId, int itemId);
        void ReduceQuantityItem(int userId, int itemId);
        void ClearCart(int userId);
    }
}
