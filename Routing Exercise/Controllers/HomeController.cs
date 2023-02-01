using Microsoft.AspNetCore.Mvc;
using Routing_Exercise.Models;
using System.Diagnostics;

namespace Routing_Exercise.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

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
        [Route("home/{cowNumber}")]
        public IActionResult Cows(int? cowNumber)
        {
            return Content($"The cow Default Cow moos at you {cowNumber?.ToString() ?? "NULL"} times.");
        }
        [Route("home/{cowNumber}/{cowName}")]
        public IActionResult Cows(int? cowNumber, string? cowName)
        {
            return Content($"The cow {cowName ?? "NULL"} moos at you {cowNumber?.ToString() ?? "NULL"} times.");
        }
        [Route("home/AllCows/Gallery/{pageNum}")]
        public IActionResult CowGallery(int? pageNum)
        {
            return Content($"There are {pageNum?.ToString() ?? "NULL"} cows.");
        }
        [Route("home/AllCows/Gallery/{cowNumber}/page{pageNum}")]
        public IActionResult CowGallery(int? cowNumber, int? pageNum)
        {
            return Content($"There are {cowNumber?.ToString() ?? "NULL"} cows on page {pageNum?.ToString() ?? "NULL"}.");
        }
        [Route("home/AllCows/Gallery/{cowNumber}/{pageNum}")]
        public IActionResult CowGallery2(int? cowNumber, int? pageNum)
        {
            return Content($"There are {cowNumber?.ToString() ?? "NULL"} cows on page {pageNum?.ToString() ?? "NULL"}.");
        }
        [Route("home/EatMoreChicken")]
        public IActionResult Chickn()
        {
            return Redirect("https://www.chick-fil-a.com/");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}