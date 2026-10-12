using System.ComponentModel.DataAnnotations;

namespace NewMicroservice.Web.Pages.Auth.SignIn
{
    public record SignInViewModel
    {
        [Display(Name = "Email :")]
        [Required(ErrorMessage = "Email is required")]
        public required string Email { get; init; }

        [Display(Name = "Password:")]
        [Required(ErrorMessage = "Password is required")]
        public required string Password { get; init; }


        public static SignInViewModel Empty => new()
        {
            Email = string.Empty,
            Password = string.Empty
        };

        public static SignInViewModel GetExampleModel => new()
        {
            Email = "ahmetyildiz",
            Password = "Password12*"
        };
    }
}
