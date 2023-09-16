using KheftProject.Core.DataAccess.Repository.Abstraction;
using KheftProject.Payment.DataAccess.Entities;

namespace KheftProject.Payment.DataAccess.Repositories.Abstraction;

internal interface ITransactionRepository : IBaseRepository<TransactionEntity>
{
}