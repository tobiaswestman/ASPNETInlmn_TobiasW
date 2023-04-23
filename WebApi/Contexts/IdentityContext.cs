using WebApi.Models.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Contexts
{
	public class IdentityContext : IdentityDbContext
	{
		public IdentityContext(DbContextOptions<IdentityContext> options) : base(options)
		{
		}

		public DbSet<UserEntity> Users { get; set; }
	}
}
