using WebApi.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace WebApi.Repositories.Base;

public abstract class IdentityRepo<TEntity> where TEntity : class
{
    private readonly IdentityContext _context;

    protected IdentityRepo(IdentityContext context)
    {
        _context = context;
    }

    public virtual async Task<TEntity> AddAsync(TEntity entity)
    {
        _context.Set<TEntity>().Add(entity);
        await _context.SaveChangesAsync();

        return entity;
    }

    public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        return await _context.Set<TEntity>().ToListAsync();
    }

    public virtual async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate)
    {
        var entity = await _context.Set<TEntity>().FirstOrDefaultAsync(predicate);
        if (entity != null)
            return entity;
        return null!;
    }

    public virtual async Task<IEnumerable<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> predicate)
    {
        var entities = await _context.Set<TEntity>().Where(predicate).ToListAsync();

        if (entities != null)
            return entities;

        return null!;
    }
}
