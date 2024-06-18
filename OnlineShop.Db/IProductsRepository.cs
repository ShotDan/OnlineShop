using OnlineShop.Db.Models;

namespace OnlineShop.Db
{
    public interface IProductsRepository
    {
        List<ProductDbModel> GetProducts();
        ProductDbModel GetProduct(Guid id);
        void DelProduct(ProductDbModel product);
        void AddProduct(ProductDbModel product);
        void EditProduct(ProductDbModel product);
    }
}
