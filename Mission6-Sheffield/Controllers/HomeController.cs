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
        public IActionResult addToCollection(int? movieId) // show form to add to collection
        {
            ViewBag.Categories = _cat_context.Categories.ToList(); // list of categories
            ViewBag.Ratings = _context.Movies.Select(x => x.Rating).Distinct().ToList(); // list of ratings
            ViewBag.Name = "Add to Collection"; // title of page

            if (movieId != null) // if movieId is not null
            {
                ViewBag.Movie = _context.Movies
                                .Include(x => x.Category)
                                .Single(x => x.MovieId == movieId);
            }
            else // if movieId is null
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

            if (ModelState.IsValid) // check if model is valid
            {
                _context.Movies.Add(response);
                _context.SaveChanges();
                ViewBag.Message = "Thank you for adding a movie to Joel's collection!"; // success message
                return View("success");
            }
            else // if model is not valid
            {
                ViewBag.Movie = response;
                ViewBag.Categories = _cat_context.Categories.ToList();
                return View(response); // return view with response
            }

        }

        public IActionResult ViewCollection() // return view of collection
        {
            var movies = _context.Movies.Include(x => x.Category).ToList(); // list of movies

            return View(movies);
        }

        [HttpGet]
        public IActionResult Edit(int MovieId) // redirect to form with movie data to edit
        {
            ViewBag.Categories = _cat_context.Categories.ToList(); // list of categories
            ViewBag.Ratings = _context.Movies.Select(x => x.Rating).Distinct().ToList(); // list of ratings
            ViewBag.Name = "Edit Movie"; // title of page
            ViewBag.movie = _context.Movies
                                .Include(x => x.Category)
                                .Single(x => x.MovieId == MovieId);

            return View("addToCollection");
        }

        [HttpPost]
        public IActionResult Edit(movies response) // post new edits to database
        {
            _context.Movies.Update(response);
            _context.SaveChanges();
            return View("success");
        }

        [HttpGet]
        public IActionResult Delete(int MovieId) // show delete view
        {
            ViewBag.movie = _context.Movies
                                .Include(x => x.Category)
                                .Single(x => x.MovieId == MovieId);
            return View();
        }
        [HttpPost]
        public IActionResult Delete(movies response) // delete movie after confirmation
        {
            _context.Movies.Remove(response);
            _context.SaveChanges();
            ViewBag.Message = "Movie Deleted Successfully";
            return View("success");
        }

    }
}
