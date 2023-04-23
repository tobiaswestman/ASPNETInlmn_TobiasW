using WebApp.Models.dtos;
using System.ComponentModel.DataAnnotations;

namespace WebApp.ViewModels;

public class AddProductViewModel
{
	[Required(ErrorMessage = "This field is required")]
	[MaxLength(50, ErrorMessage = "Max 50 characters")]
	public string Title { get; set; } = null!;

	[Required(ErrorMessage = "This field is required")]
	[MaxLength(200, ErrorMessage = "Max 200 characters")]
	public string Description { get; set; } = null!;

	[Required(ErrorMessage = "This field is required")]
	[Range(0, double.MaxValue, ErrorMessage = "Invalid price")]
	public double Price { get; set; }

	[Required(ErrorMessage = "This field is required")]
	[Range(1, 5, ErrorMessage = "Rating must be a number between 1-5")]
	public int StarRating { get; set; }


	[Required(ErrorMessage = "This field is required")]
	public string Tag { get; set; } = null!;

	public string? ImageUrl { get; set; }

	public string ConfirmationMessage { get; set; } = "";


	public static implicit operator CreateProductDTO(AddProductViewModel model)
	{
		return new CreateProductDTO
		{
			Title = model.Title,
			Description = model.Description,
            ImageUrl = model.ImageUrl,
            Price = model.Price,
			StarRating = model.StarRating,
			Tag = model.Tag,
		};
	}
}
