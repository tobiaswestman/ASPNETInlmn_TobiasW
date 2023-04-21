using WebApp.Models.dtos;

namespace WebApp.ViewModels;

public class HomeViewModel
{
	public ShowcaseDTO ShowCase { get; set; } = null!;
	public IEnumerable<ProductDTO> Featured { get; set; } = new List<ProductDTO>();
	public IEnumerable<ProductDTO> Popular { get; set; } = new List<ProductDTO>();
    public IEnumerable<ProductDTO> New { get; set; } = new List<ProductDTO>();
}
