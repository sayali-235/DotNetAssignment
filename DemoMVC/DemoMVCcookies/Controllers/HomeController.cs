using System.Diagnostics;
using DemoMVCcookies.Models;
using Microsoft.AspNetCore.Mvc;

namespace DemoMVCcookies.Controllers
{
    public class HomeController : Controller
    {
         

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(User user)
        {
            CookieOptions options = new CookieOptions();
            options.Expires = DateTime.Now.AddMinutes(10);
            Response.Cookies.Append("Name", $"{user.USerName}");
            return RedirectToAction("DashBoard");
        }
        public IActionResult DashBoard()
        {
            @ViewBag.UserName = Request.Cookies["Name"];
            return View();

        }

        
    }
}
