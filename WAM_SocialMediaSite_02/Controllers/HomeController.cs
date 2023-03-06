using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;
using WAM_SocialMediaSite_02.Models;
using WAM_SocialMediaSite_02.Interface;
using System.Reflection.Metadata.Ecma335;

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
            if (userDal.GetUserById(User.FindFirstValue(ClaimTypes.NameIdentifier)) == null)
            {
                return RedirectToAction("EditUserPage", "Home");
            }
            string x;
            x = User.FindFirstValue(ClaimTypes.NameIdentifier);
            ViewBag.UserID = x ?? string.Empty;
            if (ViewBag.UserID == string.Empty)
            {
                return RedirectToAction("EditUserPage", "Home");
            }
            return View(userDal.GetUserById(x));
        }

        [Authorize]
        [HttpGet]
        public IActionResult EditUserPage(string id)
        {
            ViewBag.UserID = User.FindFirstValue(ClaimTypes.NameIdentifier);
            ViewBag.Email = User.FindFirstValue(ClaimTypes.Email);

            if (userDal.GetUserById(id) == null)
            {
                if(userDal.GetUserById(User.FindFirstValue(ClaimTypes.NameIdentifier)) == null)
                {
                    ViewBag.IsUser = false;

                    ViewBag.UserID = User.FindFirstValue(ClaimTypes.NameIdentifier);
                    ViewBag.Email = User.FindFirstValue(ClaimTypes.Email);
                    ViewBag.Password = "lmao you thought";
                    User user = new User();
                    user.profileID = id;
                    return View(user);
                }
                else
                {
                    ViewBag.IsUser = true;

                    return View(userDal.GetUserById(User.FindFirstValue(ClaimTypes.NameIdentifier)));
                }

            }
            ViewBag.IsUser = true;


            return View(userDal.GetUserById(User.FindFirstValue(ClaimTypes.NameIdentifier)));
        }
        [Authorize]
        [HttpPost]
        public IActionResult EditUserPage(User user)
        {
            if (userDal.GetUserById(User.FindFirstValue(ClaimTypes.NameIdentifier)) == null)
            {
                userDal.AddUser(user);
            }
            else
            {
                userDal.EditUser(user);
            }

            return RedirectToAction("UserPage", "Home");
        }

        [Authorize]
        [HttpGet]
        public IActionResult CreatePost()
        {
            if (userDal.GetUserById(User.FindFirstValue(ClaimTypes.NameIdentifier)) == null)
            {
                return RedirectToAction("EditUserPage", "Home");
            }
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
        //[Route("")]
        public IActionResult Thread()
        {
            if (userDal.GetUserById(User.FindFirstValue(ClaimTypes.NameIdentifier)) == null)
            {
                return RedirectToAction("EditUserPage", "Home");
            }
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