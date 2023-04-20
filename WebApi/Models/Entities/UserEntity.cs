using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApi.Models.Identity;

namespace WebApi.Models.Entities;

public class UserEntity
{
    [Key, ForeignKey(nameof(User))]
    public string UserId { get; set; }
    public string FirstName { get; set; }
    public string LasName { get; set; }

    public CustomUserIdentity User { get; set; }
}