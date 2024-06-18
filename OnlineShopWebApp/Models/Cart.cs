namespace OnlineShopWebApp.Models
{
    public class Cart
    {
        public static int Id { get; private set; }
        public int UserId { get; private set; }
        public List<CartItem> CartItems { get; private set; }
        public decimal CostAllItems => CartItems.Sum(x => x.Cost);
        public int QuantityAllItems => CartItems.Sum(x => x.Quantity);

        public Cart(int userId, List<CartItem> cartItems)
        {
            Id = 1;
            UserId = userId;
            CartItems = cartItems;
        }
    }
}
