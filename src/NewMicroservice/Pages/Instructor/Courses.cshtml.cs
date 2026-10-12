using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NewMicroservice.Pages.Auth.SignUp;
using NewMicroservice.Web.Pages.Auth.SignIn;
using NewMicroservice.Web.Pages.Instructor.ViewModels;
using NewMicroservice.Web.Services;

namespace NewMicroservice.Pages.Instructor
{
    public class CoursesModel(CatalogService catalogService) : PageModel
    {
        public List<CourseViewModel> CourseViewModels { get; set; } = null!;

        public async Task OnGetAsync()
        {
            var result = await catalogService.GetCoursesByUserId();

            if (result.IsFail)
            {
                //TODO : redirect error page
            }

            CourseViewModels = result.Data!;
        }


        public async Task<IActionResult> OnGetDeleteAsync(Guid id)
        {
            var result = await catalogService.DeleteAsync(id);
            if (result.IsFail)
            {
                //TODO : redirect error page
            }

            return RedirectToPage();
        }
    }
}
