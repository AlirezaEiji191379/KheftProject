using KheftProject.Core.DataAccess.Repository.Abstraction;

namespace KheftProject.Core.DataAccess.Repository;

public class UnitOfWork : IUnitOfWork
{
    private readonly KheftDbContext _dbContext;

    public UnitOfWork(KheftDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return _dbContext.SaveChangesAsync(cancellationToken);
    }
}