using MVCCoreProductList1.Models;

namespace MVCCoreProductList1.Repository
{
    public interface IProductRepository
    {
        List<Product> GetProducts();
    }
}
