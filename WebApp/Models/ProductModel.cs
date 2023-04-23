namespace WebApp.Models;

public class ProductModel
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public double Price { get; set; }
    public string ImageUrl { get; set; } = null!;
    public string Tag { get; set; } = null!;
    public string Description { get; set; } = null!;
    public int StarRating { get; set; }

}
