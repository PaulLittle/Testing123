using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SAC_Web_Application.Controllers
{
    [RequireHttps]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }
        public IActionResult Information()
        {
            ViewData["Message"] = "Information page.";

            return View();
        }
        public IActionResult Subscriptions()
        {
            ViewData["Message"] = "Registration page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
