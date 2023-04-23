using System.ComponentModel.DataAnnotations;

namespace WebApi.Models.Entities;

public class CommentEntity
{
    [Key]
    public int Id { get; set; }
    [MaxLength(100)]
    public string Name { get; set; } = null!;
    [MaxLength(50)]
    public string Email { get; set; } = null!;
    public string Comment { get; set; } = null!;
}
