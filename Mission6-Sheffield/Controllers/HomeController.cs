using Microsoft.AspNetCore.Mvc;
using Mission6_Sheffield.Models;
using System.Diagnostics;

namespace Mission6_Sheffield.Controllers
{
    public class HomeController : Controller
    {
        private MovieContext _context; // add private variable to reference in class
        public HomeController(MovieContext movie) // constructor
        {
            _context = movie;
        }
        public IActionResult Index() // Index action
        {
            return View();
        }

        public IActionResult about() // about action
        {
            return View();
        }
        [HttpGet]
        public IActionResult addToCollection() // add toCollection
        {

            return View();
        }

        [HttpPost]
        public IActionResult addToCollection(movies response) // add toCollection
        {
            _context.Movies.Add(response);
            _context.SaveChanges();
            return View("success");
        }

    }
}
