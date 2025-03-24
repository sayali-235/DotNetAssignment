using MVCCoreProductWithList.Models;

namespace MVCCoreProductWithList.Repository
{
    public class ProductRepository:IProductRepository
    {
        List<Product> products;
        public ProductRepository()
        {
            products = new List<Product>()

            {
                new Product() { Id = 1, Name = "TV" }
            };
            
        }
        public List<Product> GetProducts()
        {
            return products;
        }
    }
}
