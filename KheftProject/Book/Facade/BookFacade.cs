using KheftProject.Book.DataAccess.Entity.Enums;
using KheftProject.Book.DataAccess.Repositories.Abstractions;
using KheftProject.Book.Facade.Abstractions;

namespace KheftProject.Book.Facade;

internal class BookFacade : IBookFacade
{
    private readonly IBookMetaDataRepository _bookMetaDataRepository;

    public BookFacade(IBookMetaDataRepository bookMetaDataRepository)
    {
        _bookMetaDataRepository = bookMetaDataRepository;
    }

    public void SetBookPaid(Guid bookId)
    {
        _bookMetaDataRepository.ChangeBookStatus(bookId, BookStatus.Pending);
    }
}