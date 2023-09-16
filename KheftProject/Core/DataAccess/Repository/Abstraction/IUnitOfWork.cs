using Microsoft.EntityFrameworkCore.Storage;

namespace KheftProject.Core.DataAccess.Repository.Abstraction;

public interface IUnitOfWork
{
    Task SaveChangesAsync(CancellationToken cancellationToken = default);
    Task<IDbContextTransaction> BeginTransactionAsync();
}