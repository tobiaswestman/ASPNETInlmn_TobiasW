using WebApi.Contexts;
using WebApi.Models.Entities;
using WebApi.Models.DTO;
using WebApi.Repositories.Base;

namespace WebApi.Repositories;

public class ShowcaseRepo : Repository<ShowcaseEntity>
{
    public ShowcaseRepo(DataContext dataContext) : base(dataContext)
    {
    }

    public async Task<ShowcaseDTO> GetLatestShowcaseAsync()
    {
        var showcases = await GetAllAsync();
        return showcases.OrderByDescending(x => x.Date).FirstOrDefault()!;
    }
}
