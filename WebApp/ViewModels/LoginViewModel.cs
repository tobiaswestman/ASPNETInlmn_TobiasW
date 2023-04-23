using WebApp.Models.dtos;
using System.ComponentModel.DataAnnotations;

namespace WebApp.ViewModels;

public class LoginViewModel
{
	[Required(ErrorMessage = "This field is required")]
	public string Email { get; set; } = null!;

	[Required(ErrorMessage = "This field is required")]
	[DataType(DataType.Password)]
	public string Password { get; set; } = null!;

	public static implicit operator LoginDTO(LoginViewModel model)
	{
		return new LoginDTO
		{
			Email = model.Email,
			Password = model.Password
		};
	}
}
