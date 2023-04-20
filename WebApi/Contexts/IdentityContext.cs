using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Contexts;

public class IdentityContext : IdentityDbContext
{
    public IdentityContext(DbContextOptions options) : base(options)
    {
    }
    
    public DbSet<UserProfileEntity> UserProfile { get; set; }
}