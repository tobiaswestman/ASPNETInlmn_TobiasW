using System.ComponentModel.DataAnnotations;

namespace WebApp.Models.dtos;

public class RegisterDTO
{
	public string FirstName { get; set; } = null!;
	public string LastName { get; set; } = null!;

	[RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$")]
	public string Email { get; set; } = null!;

	[RegularExpression(@"^(?=.*[A-Z])(?=.*[a-z])(?=.*[0-9])(?=.*[^a-zA-Z0-9]).{8,}$")]
	public string Password { get; set; } = null!;

	public string RoleName { get; set; } = "ProductManager";
}
