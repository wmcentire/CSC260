using Microsoft.AspNetCore.Mvc;
using Movies.Models;
using System.Diagnostics;

namespace Movies.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private static int intCount = 0;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()//you can put variables in here
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Future()
        {
            return View();
        }

        public IActionResult Past()
        {
            return View();
        }

        public IActionResult ParamTest(int? id)
        {
            return Content($"id = {id?.ToString() ?? "NULL"}");
            // Forms will always win in a fight against route and query
        }
        // ?? if null do thing to the right

        public IActionResult Counter()
        {
            ViewBag.Count = intCount++;
            //ViewData["Count"] = intCount;
            //return Redirect("https://github.com/wmcentire/UnityAI-real-");
            return View();
        }

        public IActionResult MadLibIn()
        {
            ViewData["Title"] = "Input Form";
            return View();
        }

        public IActionResult GameLibrary(string[] games, DateTime[] rentDates)// take in date and videogame
        {
            return View();
        }

        public IActionResult MadLibOut(string noun1, string adjective1, string adjective2, string verb1, string adverb1, string noun2, string adjective3)
        {
            ViewBag.VN1 = noun1;
            ViewBag.VN1 = noun1;
            ViewBag.VA1 = adjective1;
            ViewBag.VA2 = adjective2;
            ViewBag.VA3 = adjective3;
            ViewBag.VD1 = adverb1;
            ViewBag.VV1 = verb1;
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}