using KheftProject.Book.DataAccess.Entity;
using KheftProject.Core.DataAccess.Repository.Abstraction;

namespace KheftProject.Book.DataAccess.Repositories.Abstractions;

internal interface IBookRepository : IBaseRepository<BookEntity>
{
    void AcceptBook(Guid bookId);
    void SetBookPaid(Guid bookId);
    Task<bool> IsBookPaid(Guid bookId);
}