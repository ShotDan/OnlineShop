using OnlineShopWebApp.Interfaces;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Services
{
    public class CartsRepository : ICartsRepository
    {
        private List<Cart> _carts = new List<Cart>();
        private const int _itemId = 1;

        public CartsRepository()
        {
            AddCart(1);
            AddCart(2);
            AddCart(3);
        }

        private void AddCart(int userId)
        {
            var items = new List<CartItem>();
            var cart = new Cart(userId, items);
            _carts.Add(cart);
        }

        public void AddItemInCart(int userId, ProductViewModel product)
        {
            if (product == null)
                return;

            var cart = _carts.Find(x => x.UserId == userId);
            var existingItem = cart.CartItems.Find(item => item.Product.Id == product.Id);

            if (existingItem != null)
            {
                existingItem.Quantity++;
            }
            else
            {
                var cardItem = new CartItem(product);
                cardItem.Quantity++;
                cart.CartItems.Add(cardItem);
            }
        }

        public Cart? GetCart(int userId)
        {
            return _carts.Find(x => x.UserId == userId);
        }

        public void IncreaseQuantityItem(int userId, int itemId)
        {
            var cart = _carts.Find(x => x.UserId == userId);
            var item = cart.CartItems.Find(x => x.Id == itemId);

            if (item == null)
                return;

            item.Quantity++;
        }

        public void ReduceQuantityItem(int userId, int itemId)
        {
            var cart = _carts.Find(x => x.UserId == userId);
            var item = cart.CartItems.Find(x => x.Id == itemId);

            if (item == null)
                return;

            item.Quantity--;

            if (item.Quantity <= 0)
            {
                cart.CartItems.Remove(item);
            }
        }

        public void ClearCart(int userId)
        {
            var cart = _carts.Find(x => x.UserId == userId);
            cart.CartItems.Clear();
        }
    }
}
