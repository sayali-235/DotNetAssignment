using MVCCoreProductWithList.Models;

namespace MVCCoreProductWithList.Repository
{
    public interface IProductRepository
    {
        List<Product> GetProducts();
    }
}
