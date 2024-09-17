using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TestWebApplication.DB.Models;

namespace TestWebApplication.Models;

public class MainPageModel : PageModel
{
    [BindProperty]
    public Project Project { get; set; } = new Project
    {
        ProjectEnabled = true,
        SupportedImageType = "JPG"
    };

    public bool IsFormValid => !string.IsNullOrWhiteSpace(Project.ProjectName);

    public void OnGet()
    {
    }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        // Logic to save the project and navigate to the list of existing projects
        return RedirectToPage("/ListProjects");
    }
}