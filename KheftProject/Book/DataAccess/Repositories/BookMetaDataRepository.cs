using KheftProject.Book.DataAccess.Entity;
using KheftProject.Book.DataAccess.Entity.Enums;
using KheftProject.Book.DataAccess.Repositories.Abstractions;
using KheftProject.Core.DataAccess;
using KheftProject.Core.DataAccess.Repository;
using Microsoft.EntityFrameworkCore;

namespace KheftProject.Book.DataAccess.Repositories;

internal class BookMetaDataRepository : BaseRepository<BookMetaDataEntity>,IBookMetaDataRepository
{
    private readonly KheftDbContext _dbContext;
    public BookMetaDataRepository(KheftDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public void ChangeBookStatus(Guid bookId, BookStatus bookStatus)
    {
        var book = new BookMetaDataEntity()
        {
            BookId = bookId
        };
        _dbContext.Attach(book);
        book.BookStatus = bookStatus;
        _dbContext.Entry(book).Property(x => x.BookStatus).IsModified = true;
    }

    public Task<bool> IsBookPaid(Guid bookId)
    {
        return _dbContext.BookMetaData.AnyAsync(x => x.BookStatus != BookStatus.NotPaid && x.BookId == bookId);
    }
}