using WebApi.Contexts;
using WebApi.Models.Entities;
using WebApi.Repositories.Base;

namespace WebApi.Repositories;

public class TagRepo : Repository<TagEntity>
{
    public TagRepo(DataContext dataContext) : base(dataContext)
    {
    }
    
}
