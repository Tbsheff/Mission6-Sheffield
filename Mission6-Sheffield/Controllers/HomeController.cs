using Microsoft.AspNetCore.Mvc;
using Mission6_Sheffield.Models;
using System.Diagnostics;
using System.Linq;
using Microsoft.EntityFrameworkCore;


namespace Mission6_Sheffield.Controllers
{
    public class HomeController : Controller
    {
        private MovieContext _context;
        private CategoriesContext _cat_context; // add private variable to reference in class
        public HomeController(MovieContext movie, CategoriesContext categories) // constructor
        {
            _context = movie;
            _cat_context = categories;
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
        public IActionResult addToCollection(int? movieId)
        {
            ViewBag.Categories = _cat_context.Categories.ToList();
            ViewBag.Ratings = _context.Movies.Select(x => x.Rating).Distinct().ToList();
            ViewBag.Name = "Add to Collection";

            if (movieId != null)
            {
                ViewBag.Movie = _context.Movies
                                .Include(x => x.Category)
                                .Single(x => x.MovieId == movieId);
            }
            else
            {
                ViewBag.Movie = new movies
                {
                    Category = new Categories() // Assuming Categories is the type of Category property in movies class
                };
            }

            return View();
        }


        [HttpPost]
        public IActionResult addToCollection(movies response) // add toCollection
        {

            if (ModelState.IsValid)
            {
                _context.Movies.Add(response);
                _context.SaveChanges();
                ViewBag.Message = "Thank you for adding a movie to Joel's collection!";
                return View("success");
            }
            else
            {
                ViewBag.Movie = response;
                ViewBag.Categories = _cat_context.Categories.ToList();
                return View(response);
            }

        }

        public IActionResult ViewCollection()
        {
            var movies = _context.Movies.Include(x => x.Category).ToList();

            return View(movies);
        }

        [HttpGet]
        public IActionResult Edit(int MovieId)
        {
            ViewBag.Categories = _cat_context.Categories.ToList();
            ViewBag.Ratings = _context.Movies.Select(x => x.Rating).Distinct().ToList();
            ViewBag.Name = "Edit Movie";
            ViewBag.movie = _context.Movies
                                .Include(x => x.Category)
                                .Single(x => x.MovieId == MovieId);

            return View("addToCollection");
        }

        [HttpPost]
        public IActionResult Edit(movies response)
        {
            _context.Movies.Update(response);
            _context.SaveChanges();
            return View("success");
        }
        [HttpGet]
        public IActionResult Delete(int MovieId)
        {
            ViewBag.movie = _context.Movies
                                .Include(x => x.Category)
                                .Single(x => x.MovieId == MovieId);
            return View();
        }
        [HttpPost]
        public IActionResult Delete(movies response)
        {
            _context.Movies.Remove(response);
            _context.SaveChanges();
            ViewBag.Message = "Movie Deleted Successfully";
            return View("success");
        }

    }
}
