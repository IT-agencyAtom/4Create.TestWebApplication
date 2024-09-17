using Microsoft.AspNetCore.Mvc;
using TestWebApplication.DB.Common;
using TestWebApplication.DB.Models;

namespace TestWebApplication.Controllers
{
    public class ProjectsController(TestAppDbContext _context) : Controller
    {
        public IActionResult MainPage(int? projectId = null)
        {
            if (HttpContext.Session.GetString("UserSession") != null)
            {
                ViewData["MySession"] = HttpContext.Session.GetString("UserSession").ToString();
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }

            if (projectId == null)
            {
				return View(new Project());
			}

            var project = _context.Projects.FirstOrDefault(p => p.Id == projectId);
            return project == null ? NotFound() : View(project);
        }

        [HttpPost]
        public IActionResult AddProject(Project project)
        {
            var existingProject = _context.Projects.FirstOrDefault(x => x.ProjectName == project.ProjectName);
            if (existingProject != null)
                ViewBag.Message = "Project with the same name already exists";
            else
            {
                _context.Projects.Add(project);
                _context.SaveChanges();

                return RedirectToAction("AllProjects", "Projects");
            }
            return View("MainPage", project);
        }

        public IActionResult AllProjects()
        {
            if (HttpContext.Session.GetString("UserSession") != null)
            {
                ViewData["MySession"] = HttpContext.Session.GetString("UserSession").ToString();
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }

            var projects = _context.Projects.ToList();
            return View(projects);
        }
	}
}
