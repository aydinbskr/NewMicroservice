using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NewMicroservice.Web.PageModels;
using NewMicroservice.Web.Pages.Instructor.ViewModels;
using NewMicroservice.Web.Services;

namespace NewMicroservice.Pages
{
    public class IndexModel(CatalogService catalogService, ILogger<IndexModel> logger) : BasePageModel
    {
        public List<CourseViewModel>? Courses { get; set; } = [];


        public async Task<IActionResult> OnGet()
        {
            var coursesAsResult = await catalogService.GetAllCoursesAsync();

            if (coursesAsResult.IsFail) return ErrorPage(coursesAsResult);

            Courses = coursesAsResult.Data!;

            return Page();
        }
    }
}
