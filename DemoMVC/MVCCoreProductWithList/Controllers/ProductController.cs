using Microsoft.AspNetCore.Mvc;
using MVCCoreProductWithList.Models;
using MVCCoreProductWithList.Repository;

namespace MVCCoreProductWithList.Controllers
{
    public class ProductController : Controller
    {
        readonly IProductRepository _productRepository;
        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public IActionResult GetProducts()
        {
            List<Product>allProducts =_productRepository.GetProducts();
            return View(allProducts);
        }
    }
}
