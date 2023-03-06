using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;
using WAM_SocialMediaSite_02.Models;
using WAM_SocialMediaSite_02.Interface;

namespace WAM_SocialMediaSite_02.Controllers
{
    public class HomeController : Controller
    {
        IDataAccessLayer dal;
        IDataAccessLayerU userDal;
        public HomeController(IDataAccessLayer indal, IDataAccessLayerU inUserDal)
        {
            dal = indal;
            userDal = inUserDal;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult AboutMe()
        {
            return View();
        }
        [Authorize]
        public IActionResult UserPage(string id)
        {
            string x;
            x = User.FindFirstValue(ClaimTypes.NameIdentifier);
            ViewBag.UserID = x ?? string.Empty;
            if (ViewBag.UserID == string.Empty)
            {
                return View(userDal.GetUserById(id));
            }
            return View(userDal.GetUserById(x));
        }
        [Authorize]
        [HttpGet]
        public IActionResult CreatePost()
        {
            string x;
            x = User.FindFirstValue(ClaimTypes.NameIdentifier); //id
            ViewBag.UserID = x ?? string.Empty;
            return View();
        }
        [Authorize]
        [HttpPost]
        public IActionResult CreatePost(PostClass post)
        { 
            if (ModelState.IsValid)
            {
                dal.AddPost(post);
                TempData["success"] = "Posted";
                return RedirectToAction("Thread", "Home");
            }

            return View();
        }

        [Authorize]
        public IActionResult Thread()
        {
            ViewBag.UserID = User.FindFirstValue(ClaimTypes.NameIdentifier);
            foreach (PostClass post in dal.GetPosts())
            {
                post.lookUser = User.FindFirstValue(ClaimTypes.NameIdentifier);
            }
            return View(dal.GetPosts());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}