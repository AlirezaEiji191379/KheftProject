using KheftProject.Book.DataAccess.Entity;
using KheftProject.Book.DataAccess.Repositories.Abstractions;
using KheftProject.Core.DataAccess;
using KheftProject.Core.DataAccess.Repository;

namespace KheftProject.Book.DataAccess.Repositories;

public class BookRepository : BaseRepository<BookEntity>, IBookRepository
{
    public BookRepository(KheftDbContext dbContext) : base(dbContext)
    {
    }
}