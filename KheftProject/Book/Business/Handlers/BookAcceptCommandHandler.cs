using KheftProject.Book.Business.Contracts.Commands;
using KheftProject.Book.DataAccess.Repositories.Abstractions;
using KheftProject.Core.Contexts;
using KheftProject.Core.DataAccess.Repository.Abstraction;
using MediatR;

namespace KheftProject.Book.Business.Handlers;

internal class BookAcceptCommandHandler : IRequestHandler<BookAcceptCommand, ResponseDto>
{
    private readonly IBookRepository _bookRepository;
    private readonly IUnitOfWork _unitOfWork;

    public BookAcceptCommandHandler(IBookRepository bookRepository, IUnitOfWork unitOfWork)
    {
        _bookRepository = bookRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<ResponseDto> Handle(BookAcceptCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var isPaid = await _bookRepository.IsBookPaid(request.BookId);
            if (!isPaid)
            {
                return new ResponseDto()
                {
                    Message = "the book is not exist or the price was not paid",
                    StatusCode = 404
                };
            }
            _bookRepository.AcceptBook(request.BookId);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return new ResponseDto()
            {
                Message = "book accepted!",
                StatusCode = 200
            };
        }
        catch (Exception exception)
        {
            return new ResponseDto()
            {
                Message = exception.Message,
                StatusCode = 400
            };
        }
    }
}