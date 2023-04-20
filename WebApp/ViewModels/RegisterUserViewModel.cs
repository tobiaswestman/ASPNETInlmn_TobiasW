using System.ComponentModel.DataAnnotations;

namespace WebApp.ViewModels
{
    public class RegisterUserViewModel
    {
      
        [Required(ErrorMessage = "You need to enter a first name")]
        public string FirstName { get; set; } = null!;


        [Required(ErrorMessage = "You need to enter a last name ")]
        public string LastName { get; set; } = null!;


        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;
        public string? PhoneNumber { get; set; }


        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;


        [Required]
        [DataType(DataType.Password)]
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; } = null!;

    }
}
