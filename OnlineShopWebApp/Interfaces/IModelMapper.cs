using OnlineShop.Db.Models;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Interfaces
{
    public interface IModelMapper
    {
        ProductViewModel MapToViewModel(ProductDbModel productDb);
        ProductDbModel MapToDbModel(ProductViewModel productView);
    }
}
