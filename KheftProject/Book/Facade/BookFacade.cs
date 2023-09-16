using KheftProject.Book.DataAccess.Entity.Enums;
using KheftProject.Book.DataAccess.Repositories.Abstractions;
using KheftProject.Book.Facade.Abstractions;

namespace KheftProject.Book.Facade;

internal class BookFacade : IBookFacade
{
    private readonly IBookRepository _bookRepository;

    public BookFacade(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    public void SetBookPaid(Guid bookId)
    {
        _bookRepository.ChangeBookStatus(bookId, BookStatus.Pending);
    }
}