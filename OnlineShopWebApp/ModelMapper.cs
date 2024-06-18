using Microsoft.AspNetCore.Mvc.ModelBinding;
using OnlineShop.Db.Models;
using OnlineShopWebApp.Interfaces;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp
{
    public class ModelMapper : IModelMapper
    {
        public ProductViewModel MapToViewModel(ProductDbModel dbProduct)
        {
            var viewProduct = new ProductViewModel
            {
                Id = dbProduct.Id,
                Name = dbProduct.Name,
                Cost = dbProduct.Cost,
                Description = dbProduct.Description
            };

            return viewProduct;
        }

        public ProductDbModel MapToDbModel(ProductViewModel viewProduct)
        {
            var dbProduct = new ProductDbModel
            {
                Id = viewProduct.Id,
                Name = viewProduct.Name,
                Cost = viewProduct.Cost,
                Description = viewProduct.Description
            };

            return dbProduct;
        }
    }
}
