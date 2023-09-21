using KheftProject.Book.DataAccess.Entity;
using KheftProject.Book.DataAccess.Entity.Enums;
using KheftProject.Core.DataAccess.Repository.Abstraction;

namespace KheftProject.Book.DataAccess.Repositories.Abstractions;

internal interface IBookMetaDataRepository : IBaseRepository<BookMetaDataEntity>
{
    void ChangeBookStatus(Guid bookId, BookStatus bookStatus);
    Task<List<Guid>> GetExpiredBookIds();
}