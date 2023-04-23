using WebApi.Contexts;
using WebApi.Models.Entities;
using WebApi.Repositories.Base;

namespace WebApi.Repositories
{
    public class UserRepo : IdentityRepo<UserEntity>
	{
		public UserRepo(IdentityContext context) : base(context)
		{
		}
	}
}
