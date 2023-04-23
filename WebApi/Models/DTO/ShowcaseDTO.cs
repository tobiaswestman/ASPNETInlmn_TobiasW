using WebApi.Models.Entities;

namespace WebApi.Models.DTO;

public class ShowcaseDTO
{
    public string Title { get; set; } = null!;
    public string OfferDescription { get; set; } = null!;
    public string OfferTitle { get; set; } = null!;
    public string ImageUrl { get; set; } = null!;

}
