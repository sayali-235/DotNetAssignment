using Microsoft.AspNetCore.Mvc;
using MVCCoreProductList1.Models;
using MVCCoreProductList1.Repository;

namespace MVCCoreProductList1.Controllers
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
            List<Product> allProducts = _productRepository.GetProducts();
            return View(allProducts);
        }
    }
}
