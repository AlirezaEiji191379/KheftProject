using KheftProject.Core.DataAccess;
using KheftProject.Core.DataAccess.Repository;
using KheftProject.Payment.DataAccess.Entities;
using KheftProject.Payment.DataAccess.Repositories.Abstraction;

namespace KheftProject.Payment.DataAccess.Repositories;

public class TransactionRepository : BaseRepository<TransactionEntity>, ITransactionRepository
{
    public TransactionRepository(KheftDbContext dbContext) : base(dbContext)
    {
    }
}