using WebApi.Models.DTO;

namespace WebApp.ViewModels;

public class HomeViewModel
{
	public ShowcaseDTO Showcase { get; set; } = null!;
	public IEnumerable<Models.ProductModel> Featured { get; set; } = new List<Models.ProductModel>();
	public IEnumerable<Models.ProductModel> Popular { get; set; } = new List<Models.ProductModel>();
    public IEnumerable<Models.ProductModel> New { get; set; } = new List<Models.ProductModel>();
}
