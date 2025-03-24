using MVCCoreProductList1.Models;

namespace MVCCoreProductList1.Repository
{
    public class ProductRepository : IProductRepository
    {
        List<Product> products;
        public ProductRepository()
        {
            products = new List<Product>()
            {
                new Product() {Id=1,Name="Sayali" }
            };
        }
        public List<Product> GetProducts()
        {
            return products;
        }
    }
}
