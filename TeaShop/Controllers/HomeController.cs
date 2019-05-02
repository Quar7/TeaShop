using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace TeaShop.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }

        [HttpGet("/Home/Error404/{statusCode}")]
        public IActionResult Error404(int statusCode)
        {
            if (statusCode == 404)
            {
                return View("404");
            }
            return View("Error");
        }
    }
}
