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
                    29.99,
                    4.5f,
                    "~/images/dwarffortressimage.png",
                    "Steam"),
            new Game("Deep Rock Galactic",
                    29.99,
                    4.9f,
                    "~/images/dwarffortressimage.png",
                    "Steam"),
            new Game("Persona 5",
                    29.99,
                    4.7f,
                    "~/images/dwarffortressimage.png",
                    "PS4/PS5"),
            new Game("Hollow Knight",
                    15,
                    4.8f,
                    "~/images/dwarffortressimage.png",
                    "Steam/PS4/XBOX/Switch"),
            new Game("Slime Rancher",
                    19.99,
                    4.5f,
                    "~/images/dwarffortressimage.png",
                    "Steam")
        
            
        };

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
        public IActionResult GameLibrary()
        {
            // games
            return View(games);
        }
        [HttpPost]
        public IActionResult GameLibrary(int? id, string Borrower)
        {
            DateTime time = DateTime.Now;

            Game aGame = games.Find(game => game.Id == id);

            aGame.CurrentOwner = Borrower;
            aGame.CheckOutDate = time;
            return View(games);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}