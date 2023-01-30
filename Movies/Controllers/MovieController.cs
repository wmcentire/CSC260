using Microsoft.AspNetCore.Mvc;
using Movies.Models;
using Movies.Interfaces;
using Movies.Data;

namespace Movies.Controllers
{
    public class MovieController : Controller
    {

        IDataAccessLayer dal = new MovieListDAL();

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult MultMovies()
        {
            return View(dal.GetMovies());
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
            Movie foundMovie = dal.GetMovieById(id);

            if (foundMovie == null)
                return NotFound();

            return View(foundMovie);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Movie m)
        {
            if (m.Title == "The Room")
            {
                ModelState.AddModelError("CustomError", "bro you really watched the room?");
            }
            if (ModelState.IsValid)
            {
                dal.AddMovie(m);
                TempData["success"] = "Movie " + m.Title + " added";
                return RedirectToAction("MultMovies", "Movie");
            }
            return View();
        }

        [HttpPost]
        public IActionResult Edit(Movie m)
        {
            int i;
            //i = dal.GetMovies().FindIndex(x => x.Id == m.Id);
            //MovieList[i] = m;
            TempData["success"] = "Movie " + m.Title + " updated";

            return RedirectToAction("MultMovies","Movie");
        }

        public IActionResult Remove(int? id)
        {
            int i;
            //i = MovieList.FindIndex(x => x.Id == id);
            //if(i != -1)
            {
                //TempData["success"] = "Movie " + MovieList[i].Title + " removed";
                //MovieList.RemoveAt(i);
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