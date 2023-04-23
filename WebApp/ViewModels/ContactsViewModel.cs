using System.ComponentModel.DataAnnotations;
using WebApp.Models.dtos;

namespace WebApp.ViewModels;

public class ContactsViewModel
{
    [Required(ErrorMessage = "You must enter a name!")]
    public string Name { get; set; } = null!;

    [EmailAddress(ErrorMessage = "You must enter a valid email!")]
    public string Email { get; set; } = null!;

    [Required(ErrorMessage = "You must enter a comment!")]
    public string Comment { get; set; } = null!;
    public string ConfirmString { get; set; } = "";

    public static implicit operator CommentDTO(ContactsViewModel viewModel)
    {
        return new CommentDTO
        {
            Name = viewModel.Name,
            Email = viewModel.Email,
            Comment = viewModel.Comment,
        };
    }
}
