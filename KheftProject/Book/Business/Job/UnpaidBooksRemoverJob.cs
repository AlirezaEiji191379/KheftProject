using KheftProject.Book.Business.Abstractions;
using KheftProject.Book.DataAccess.Entity;
using KheftProject.Book.DataAccess.Repositories.Abstractions;
using KheftProject.Core.DataAccess.Repository.Abstraction;

namespace KheftProject.Book.Business.Job;

internal class UnpaidBooksRemoverJob : IUnpaidBooksRemoverJob
{
    private readonly IBookRepository _bookRepository;
    private readonly IBookMetaDataRepository _bookMetaDataRepository;
    private readonly IUnitOfWork _unitOfWork;


    public UnpaidBooksRemoverJob(IBookRepository bookRepository,
        IBookMetaDataRepository bookMetaDataRepository,
        IUnitOfWork unitOfWork)
    {
        _bookRepository = bookRepository;
        _bookMetaDataRepository = bookMetaDataRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task RemoveUnpaidBooks()
    {
        var expiredBooks = await _bookMetaDataRepository.GetExpiredBookIds();
        expiredBooks.ForEach(id =>
        {
            _bookRepository.Delete(new BookEntity()
            {
                BookId = id
            });
        });
        await _unitOfWork.SaveChangesAsync();
    }
}