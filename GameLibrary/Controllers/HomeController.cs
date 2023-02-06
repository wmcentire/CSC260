using GameLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using GameLibrary.Interfaces;
using GameLibrary.Data;

namespace GameLibrary.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        IDataAccessLayer dal = new GameListDAL();
        
        private static int avb = 5;


        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        [HttpGet]
        public IActionResult GameLibrary(int? id)
        {
            // games
            Game? aGame = dal.GetGameById(id);
            if(aGame == null)
            {

            }
            else
            {
                aGame.Available = true;
                //avb++;
            }
            
            ViewBag.GameCount = dal.GetCollection().Count();
            return View(dal.GetCollection());
        }
        [HttpPost]
        public IActionResult GameLibrary(int? id, string Borrower) //name of string has to match in the input name
        {
            DateTime time = DateTime.Now;

            Game? aGame = dal.GetGameById(id);
            if(aGame != null)
            {
                ViewBag.GameCount = dal.GetCollection().Count();
                aGame.Available = false;
                aGame.CurrentOwner = Borrower;
                aGame.CheckOutDate = time;
            }

            return View(dal.GetCollection());
        }

        public IActionResult Search(string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                return View("GameLibrary", dal.GetCollection());
            }

            return View("GameLibrary", dal.GetCollection().Where(c => c.Title.ToLower().Contains(key.ToLower())));
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Game game)
        {
            if (1 != 1)
            {
                //ModelState.AddModelError("CustomError", "bro you really watched the room?");
            }
            if (ModelState.IsValid)
            {
                dal.AddGame(game);
                TempData["success"] = "Game " + game.Title + " added";
                return RedirectToAction("GameLibrary", "Home");
            }
            return View();
        }
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Game game = dal.GetGameById(id);

            if (game == null)
                return NotFound();

            return View(game);
        }
        [HttpPost]
        public IActionResult Edit(Game game)
        {
            dal.EditGame(game);
            TempData["success"] = "Game " + game.Title + " updated";

            return RedirectToAction("GameLibrary", "Home");
        }

        public IActionResult Remove(int? id)
        {
            if (id == null)
            {
                ModelState.AddModelError("Title", "There is no game to remove there.");
            }
            else
            {
                if (ModelState.IsValid)
                {
                    TempData["success"] = "Game " + dal.GetGameById(id).Title + " removed";

                    dal.RemoveGame(id);
                }
            }
            return RedirectToAction("GameLibrary", "Home");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}