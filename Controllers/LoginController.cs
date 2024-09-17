using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TestWebApplication.DB.Common;
using TestWebApplication.DB.Models;
using TestWebApplication.Models;

namespace TestWebApplication.Controllers
{
    public class LoginController(TestAppDbContext _context) : Controller
    {
        public IActionResult Login()
        {
            if (HttpContext.Session.GetString("UserSession") != null)
            {
                return RedirectToAction("MainPage", "Projects");
            }
            return View();
        }

        [HttpPost]
        public IActionResult Login(User u)
        {
            var myUser = _context.Users.FirstOrDefault(x => x.UserName == u.UserName && x.Password == u.Password);
            if (myUser != null)
            {
                HttpContext.Session.SetString("UserSession", myUser.UserName);
                return RedirectToAction("MainPage", "Projects");
            }
            else
            {
                ViewBag.Message = "Password or username incorrect";
            }
            return View();
        }

        public IActionResult Logout()
        {
            if (HttpContext.Session.GetString("UserSession") != null)
            {
                HttpContext.Session.Remove("UserSession");
                return RedirectToAction("Login");
            }

            return View("Login");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}