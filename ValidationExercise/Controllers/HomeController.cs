using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using ValidationExercise.Models;

namespace ValidationExercise.Controllers
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

        [HttpGet]
        public IActionResult PersonView()
        {
            return View();
        }

        [HttpPost]
        public IActionResult PersonView(PersonModel person)
        {
            if(person == null)
            {
                return View();
            }
            if(person.Street == null && person.City == null && person.State == null && person.ZipCode == null)
            {
                
            }
            else if(person.Street == null || person.City == null || person.State == null || person.ZipCode == null)
            {
                ModelState.AddModelError("CustomError","You may either fill out all parts of the address or not fill it out at all.");
            }

            if (ModelState.IsValid)
            {
                person.Address = person.Street + ", " + person.City + ", " + person.State + ", " + person.ZipCode.ToString();
            }
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}