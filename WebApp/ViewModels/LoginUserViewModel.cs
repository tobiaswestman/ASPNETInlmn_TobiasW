using System.ComponentModel.DataAnnotations;

namespace WebApp.ViewModels
{
    public class LoginUserViewModel
    {
        [Required(ErrorMessage = "You need to enter an Email")]
        public string Email { get; set; } = null!;

        [Required (ErrorMessage = "You need to enter a password")]
        public string Password { get; set; } = null!;
    }
}
