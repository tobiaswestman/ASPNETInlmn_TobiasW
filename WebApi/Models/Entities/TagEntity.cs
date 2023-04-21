﻿using System.ComponentModel.DataAnnotations;

namespace WebApi.Models.Entities;

public class TagEntity
{
    [Key]
    public int Id { get; set; }

    [MaxLength(30)]
    public string Name { get; set; } = null!;

    public IEnumerable<ProductEntity> Products { get; set; } = new List<ProductEntity>();
}
