namespace OnlineShopWebApp.Models
{
    public class CartItem
    {
        private static int nextId = 1;
        public int Id { get; private set; }
        public ProductViewModel Product { get; private set; }
        public int Quantity { get; set; }
        public decimal Cost => Product.Cost * Quantity;

        public CartItem( ProductViewModel product)
        {
            Id = nextId;
            Product = product;
            nextId++;
        }
    }
}
