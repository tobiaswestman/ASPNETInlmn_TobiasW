using WebApi.Models.Entities;

namespace WebApi.Models.DTO;

public class CommentDTO
{
    public string Name { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Comment { get; set; } = null!;

    public static implicit operator CommentEntity(CommentDTO dto)
    {
        return new CommentEntity
        {
            Email = dto.Email,
            Name = dto.Name,
            Comment = dto.Comment
        };
    }
}
