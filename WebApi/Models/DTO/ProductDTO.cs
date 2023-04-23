﻿using WebApi.Models.Entities;

namespace WebApi.Models.DTO;

public class ProductDTO
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public double Price { get; set; }
    public string? ImageUrl { get; set; } = null!;
    public string Tag { get; set; } = null!;
    public string Description { get; set; } = null!;
    public int StarRating { get; set; }

    public static implicit operator ProductDTO(ProductEntity entity)
    {
        return new ProductDTO
        {
            Id = entity.Id,
            Title = entity.Title,
            Price = entity.Price,
            ImageUrl = entity.ImageUrl,
            Tag = entity.Tag.Name,
            Description = entity.Description,
            StarRating = entity.StarRating,
        };
    }
}
