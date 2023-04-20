using System.ComponentModel.DataAnnotations;

namespace WebApp.ViewModels
{
    public class ContactsViewModel
    {
        [Required(ErrorMessage = "You need to enter a name!")]
        public string Name { get; set; } = null!;

        [EmailAddress(ErrorMessage = "You need to enter a valid Email adress")]
        public string Email { get; set; } = null!;

        //required?
        [Required(ErrorMessage = "You must enter a comment")]
        public string Comment { get; set; } = null!;
    }
}
