using KheftProject.Book.DataAccess.Entity;
using KheftProject.Book.DataAccess.Repositories.Abstractions;
using KheftProject.Core.DataAccess;
using KheftProject.Core.DataAccess.Repository;
using Microsoft.EntityFrameworkCore;

namespace KheftProject.Book.DataAccess.Repositories;

public class BookRepository : BaseRepository<BookEntity>, IBookRepository
{
    private readonly KheftDbContext _dbContext;
    
    public BookRepository(KheftDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }
    
    public void SetBookPaid(Guid bookId)
    {
        var book = new BookEntity()
        {
            BookId = bookId
        };
        _dbContext.Attach(book);
        book.IsPaid = true;
        _dbContext.Entry(book).Property(x => x.IsPaid).IsModified = true;
    }
    
    public void AcceptBook(Guid bookId)
    {
        var book = new BookEntity()
        {
            BookId = bookId
        };
        _dbContext.Attach(book);
        book.IsAccepted = true;
        _dbContext.Entry(book).Property(x => x.IsAccepted).IsModified = true;
    }

    public Task<bool> IsBookPaid(Guid bookId)
    {
        return _dbContext.Books.AnyAsync(x => x.IsPaid == true && x.BookId == bookId);
    }
}