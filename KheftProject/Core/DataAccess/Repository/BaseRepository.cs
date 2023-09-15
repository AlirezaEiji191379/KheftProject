using System.Linq.Expressions;
using KheftProject.Core.DataAccess.Repository.Abstraction;
using Microsoft.EntityFrameworkCore;

namespace KheftProject.Core.DataAccess.Repository;

public class BaseRepository<T> : IBaseRepository<T> where T : class
{
    private readonly KheftDbContext _dbContext;

    public BaseRepository(KheftDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task Create(T entity)
    {
        return _dbContext.Set<T>().AddAsync(entity).AsTask();
    }

    public void Update(T entity)
    {
        _dbContext.Set<T>().Update(entity);
    }

    public void Delete(T entity)
    {
        _dbContext.Set<T>().Remove(entity);
    }

    public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges)
    {
        return trackChanges
            ? _dbContext.Set<T>().Where(expression)
            : _dbContext.Set<T>().Where(expression).AsNoTracking();

    }

    public IQueryable<T> GetAll(bool trackChanges)
    {
        return trackChanges
            ? _dbContext.Set<T>()
            : _dbContext.Set<T>().AsNoTracking();
    }
}