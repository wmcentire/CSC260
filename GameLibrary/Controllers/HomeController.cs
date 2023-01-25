using GameLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GameLibrary.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;


        public static List<Game> games = new List<Game> { 
            new Game("Dwarf Fortress",
                    26.99,
                    4.5f,
                    "dwarffortressimage.png",
                    "Steam",
                    "Colony Sim",
                    "Not Rated"),
            new Game("Deep Rock Galactic",
                    29.99,
                    4.9f,
                    "DRG.jpg",
                    "Steam",
                    "FPS PvE",
                    "Teen"),
            new Game("Persona 5 Royal",
                    29.99,
                    4.7f,
                    "persona-5-royal.jpg",
                    "PS4/PS5",
                    "Life Sim/JRPG",
                    "Mature"),
            new Game("Hollow Knight",
                    15,
                    4.8f,
                    "HollowKnight.jpg",
                    "Steam/PS4/XBOX/Switch",
                    "Metroidvania",
                    "E10+"),
            new Game("Slime Rancher",
                    19.99,
                    4.5f,
                    "Slime-Rancher-1280x640.jpg",
                    "Steam/XBOX",
                    "Fantasy Management",
                    "E10+")
        
            
        };
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
            Game? aGame = games.Find(game => game.Id == id);
            if(aGame == null)
            {

            }
            else
            {
                aGame.Available = true;
                avb++;
            }
            
            ViewBag.GameCount = avb;
            return View(games);
        }
        [HttpPost]
        public IActionResult GameLibrary(int? id, string Borrower) //name of string has to match in the input name
        {
            DateTime time = DateTime.Now;

            Game? aGame = games.Find(game => game.Id == id);
            if(aGame != null)
            {
                ViewBag.GameCount = --avb;
                aGame.Available = false;
                aGame.CurrentOwner = Borrower;
                aGame.CheckOutDate = time;
            }

            return View(games);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}