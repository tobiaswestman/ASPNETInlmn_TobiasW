using WebApi.Models.Entities;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Models.DTO;

public class RegisterDTO
{
	public string FirstName { get; set; } = null!;
	public string LastName { get; set; } = null!;

	[RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$")]
	public string Email { get; set; } = null!;

	[RegularExpression(@"^(?=.*[A-Z])(?=.*[a-z])(?=.*[0-9])(?=.*[^a-zA-Z0-9]).{8,}$")]
	public string Password { get; set; } = null!;

	public string RoleName { get; set; } = "ProductManager";

	public static implicit operator IdentityUser(RegisterDTO model)
	{
		return new IdentityUser
		{
			UserName = model.Email,
			Email = model.Email,
		};
	}

	public static implicit operator UserEntity(RegisterDTO model)
	{
		return new UserEntity
		{
			FirstName = model.FirstName,
			LastName = model.LastName
		};
	}
}
