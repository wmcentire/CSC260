using Microsoft.AspNetCore.Mvc;
using Movies.Models;

namespace Movies.Controllers
{
    public class MovieController : Controller
    {
        private static List<Movie> MovieList = new List<Movie>
        {
            new Movie("Lion King",1994,4f),
            new Movie("Trip to the Moon",1902,5f),
            new Movie("Megamind",2010,5f),
        };

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult MultMovie()
        {
            return View(MovieList);
        }

        public IActionResult DisplayMovie()
        {
            Movie m = new Movie("Tron",1982,5f);
            return View(m);
        }
    }
}
