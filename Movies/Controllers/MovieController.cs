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

        public IActionResult MultMovies()
        {
            return View(MovieList);
        }

        public IActionResult DisplayMovie()
        {
            Movie m = new Movie("Tron",1982,5f);
            return View(m);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Movie foundMovie = MovieList.Where(m => m.Id == id).FirstOrDefault();

            if (foundMovie == null)
                return NotFound();

            return View(foundMovie);
        }

        [HttpPost]
        public IActionResult Edit(Movie m)
        {
            int i;
            i = MovieList.FindIndex(x => x.Id == m.Id);
            MovieList[i] = m;
            TempData["success"] = "Movie " + m.Title + " updated";

            return RedirectToAction("MultMovies","Movie");
        }

        public IActionResult Remove(int? id)
        {
            int i;
            i = MovieList.FindIndex(x => x.Id == id);
            if(i != null)
            {
                MovieList.RemoveAt(i);

            }
            

            return RedirectToAction("MultMovies", "Movie");
        }
    }
}

// Lambda Expressions
// 
// Game onegame = lstGames.Find(x => x.ID == ID);
// 
// Useful!