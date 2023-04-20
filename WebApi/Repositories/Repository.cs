using Microsoft.AspNetCore.Mvc;
using WebApi.Contexts;

namespace WebApi.Repositories;

public abstract class Repository<TEntity> where TEntity : class
{
    private readonly DataContext _dataContext;

    protected Repository(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public virtual async Task<TEntity> GetAsync(TEntity entity)
    {
        _dataContext.Set<TEntity>().Add(entity);
        await _dataContext.SaveChangesAsync();

        return entity;
    }
}