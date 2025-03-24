using DemoControls.Models;
using Microsoft.AspNetCore.Mvc;

namespace DemoControls.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Product product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }
            else
            {

                return Content($"Product name:: {product.Name}");
            }
        }
    }
}
