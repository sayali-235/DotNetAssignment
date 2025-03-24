using System.Diagnostics;
using DemoSessionState.Models;
using Microsoft.AspNetCore.Mvc;

namespace DemoSessionState.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
        HttpContext.Session.SetString("Name", "Sayali");
        HttpContext.Session.SetInt32("Age", 22);
        return View();
        }
        public IActionResult GetResult()
        {
            User user=new User()
            {
                Name = HttpContext.Session.GetString("Name"),
                Age=HttpContext.Session.GetInt32("Age")
            };
            return View(user);
        }
        public IActionResult privacy()
        {
            return View();
        }
        public IActionResult GetQueryString(string name,int age)
        {
            User user = new User()
            {
                Name = name,
                Age = age
            };
            return View(user);
        }

       
    }
}
