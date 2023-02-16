using Microsoft.AspNetCore.Mvc;
using Movies.Models;
using Movies.Interfaces;
using Movies.Data;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace Movies.Controllers
{
    public class MovieController : Controller
    {

        // IDataAccessLayer dal = new MovieListDAL();

        IDataAccessLayer dal;

        public MovieController(IDataAccessLayer indal)
        {
            dal = indal;
        }

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
        [Authorize]
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
                m.UserID = User.FindFirstValue(ClaimTypes.NameIdentifier);
                dal.AddMovie(m);
                TempData["success"] = "Movie " + m.Title + " added";
                return RedirectToAction("MultMovies", "Movie");
            }
            return View();
        }

        [HttpPost]
        public IActionResult Edit(Movie m)
        {
            //int i = dal.GetMovieByMovie(m);
            dal.EditMovie(m);
            TempData["success"] = "Movie " + m.Title + " updated";

            return RedirectToAction("MultMovies","Movie");
        }

        public IActionResult Remove(int? id)
        {
            if(id == null)
            {
                ModelState.AddModelError("Title", "No movie there bro");
            }
            else
            {
                if (ModelState.IsValid)
                {
                    TempData["success"] = "Movie " + dal.GetMovieById(id).Title + " removed";

                    dal.RemoveMovie(id);
                }
            }
            return RedirectToAction("MultMovies", "Movie");
        }

        public IActionResult Search(string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                return View("MultMovies", dal.GetMovies());
            }

            return View("MultMovies", dal.GetMovies().Where(c => c.Title.ToLower().Contains(key.ToLower())));
        }

        public IActionResult Filter(string Genre, string mparating)
        {
            return View("MultMovies", dal.FilterMovies(Genre, mparating));
        }
    }
}

// Lambda Expressions
// 
// Game onegame = lstGames.Find(x => x.ID == ID);
// 
// Useful!