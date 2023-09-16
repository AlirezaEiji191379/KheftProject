using KheftProject.Book.DataAccess.Entity;
using KheftProject.Core.DataAccess.Repository.Abstraction;

namespace KheftProject.Book.DataAccess.Repositories.Abstractions;

internal interface IBookRepository : IBaseRepository<BookEntity>
{
}