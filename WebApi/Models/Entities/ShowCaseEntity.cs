using System.ComponentModel.DataAnnotations;
using WebApi.Models.DTO;

namespace WebApi.Models.Entities;

public class ShowcaseEntity
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public string Title { get; set; } = null!;
    public string OfferDescription { get; set; } = null!;
    public string OfferTitle { get; set; } = null!;
    public string ImageUrl { get; set; } = null!;


    public static implicit operator ShowcaseDTO(ShowcaseEntity entity)
    {
        return new ShowcaseDTO
        {
            Title = entity.Title,
            OfferDescription = entity.OfferDescription,
            OfferTitle  = entity.OfferTitle,
            ImageUrl = entity.ImageUrl,
        };
    }
}
