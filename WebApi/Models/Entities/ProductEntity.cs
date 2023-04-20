namespace WebApi.Models.Entities;

public class ProductEntity
{
    public int ProductId { get; set; }
    public string Name { get; set; }
    public string ImageUrl { get; set; }
    public string Tag { get; set; }
    public decimal Price { get; set; }
    public DateTime DatePosted { get; set; }
}