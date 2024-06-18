using OnlineShop.Db.Models;

namespace OnlineShop.Db
{
    public class ProductsDbRepository : IProductsRepository
    {
        private readonly DataBaseContext _dataBaseContext;

        public ProductsDbRepository(DataBaseContext context)
        {
            _dataBaseContext = context;
        }

        public void AddProduct(ProductDbModel product)
        {
            _dataBaseContext.Products.Add(product);
            _dataBaseContext.SaveChanges();
        }

        public List<ProductDbModel> GetProducts()
        {
            return _dataBaseContext.Products.ToList();
        }

        public ProductDbModel GetProduct(Guid id)
        {
            return _dataBaseContext.Products.FirstOrDefault(x => x.Id == id);
        }

        public void DelProduct(ProductDbModel product)
        {
            if (product != null)
            {
                _dataBaseContext.Products.Remove(product);
                _dataBaseContext.SaveChanges();
            }
        }

        public void EditProduct(ProductDbModel product)
        {
            var existingProduct = _dataBaseContext.Products.FirstOrDefault(x => x.Id == product.Id);

            if (existingProduct == null)
            {
                return;
            }

            existingProduct.Name = product.Name;
            existingProduct.Cost = product.Cost;
            existingProduct.Description = product.Description;
            _dataBaseContext.SaveChanges();
        }
    }
}
