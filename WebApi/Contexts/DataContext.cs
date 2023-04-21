using Microsoft.EntityFrameworkCore;
using WebApi.Models.Entities;

namespace WebApi.Contexts;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions options) : base(options)
    {
    }
    
    public DbSet<ProductEntity> Products { get; set; }

    public DbSet<CommentEntity> Comments { get; set; }
    public DbSet<ShowcaseEntity> Showcases { get; set; }
    
}