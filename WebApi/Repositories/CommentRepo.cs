using WebApi.Contexts;
using WebApi.Models.Entities;
using WebApi.Repositories.Base;

namespace WebApi.Repositories;

public class CommentRepo : Repository<CommentEntity>
{
    public CommentRepo(DataContext dataContext) : base(dataContext)
    {
    }
}
