using Microsoft.AspNetCore.Mvc;
using TestWebApplication.DB.Common;
using TestWebApplication.DB.Models;
using TestWebApplication.Models;

namespace TestWebApplication.Controllers
{
    public class ProjectsController(TestAppDbContext _context) : Controller
    {
        public IActionResult MainPage()
        {
            if (HttpContext.Session.GetString("UserSession") != null)
            {
                ViewData["MySession"] = HttpContext.Session.GetString("UserSession").ToString();
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }
            return View(new MainPageModel());
        }

        [HttpPost]
        public IActionResult MainPage(Project p)
        {

            /*var myUser = _context.Users.FirstOrDefault(x => x.UserName == u.UserName && x.Password == u.Password);
            if (myUser != null)
            {
                HttpContext.Session.SetString("UserSession", myUser.UserName);
                return RedirectToAction("MainPage", "Projects");
            }
            else
            {
                ViewBag.Message = "Password or username incorrect";
            }*/
            return View();
        }
    }
}
