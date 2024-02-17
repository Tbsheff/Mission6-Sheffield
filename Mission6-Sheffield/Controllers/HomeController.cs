using Microsoft.AspNetCore.Mvc;
using Mission6_Sheffield.Models;
using System.Diagnostics;

namespace Mission6_Sheffield.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult about()
        {
            return View();
        }

        public IActionResult addToCollection()
        {
            return View();
        }



    }
}
