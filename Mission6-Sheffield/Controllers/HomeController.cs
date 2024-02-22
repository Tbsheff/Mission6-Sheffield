using Microsoft.AspNetCore.Mvc;
using Mission6_Sheffield.Models;
using System.Diagnostics;
using System.Linq;
using Microsoft.EntityFrameworkCore;


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

        public IActionResult ViewCollection()
        {
            var movies = _context.Movies.Include(x => x.Category).ToList();

            return View(movies);
        }

        public IActionResult EditCollection(int movieId)
        {
            var movie = _context.Movies.FirstOrDefault(x => x.MovieId == movieId);

            _context.Movies.Update(movie);
            _context.SaveChanges();
            return View(movie);
        }

    }
}
