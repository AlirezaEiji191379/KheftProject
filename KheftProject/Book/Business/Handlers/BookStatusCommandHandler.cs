using KheftProject.Book.Business.Contracts.Commands;
using KheftProject.Book.DataAccess.Entity.Enums;
using KheftProject.Book.DataAccess.Repositories.Abstractions;
using KheftProject.Core.Contexts;
using KheftProject.Core.DataAccess.Repository.Abstraction;
using MediatR;

namespace KheftProject.Book.Business.Handlers;

internal class BookStatusCommandHandler : IRequestHandler<BookStatusCommand, ResponseDto>
{
    private readonly IBookMetaDataRepository _bookMetaDataRepository;
    private readonly IUnitOfWork _unitOfWork;

    public BookStatusCommandHandler(IBookMetaDataRepository bookMetaDataRepository, IUnitOfWork unitOfWork)
    {
        _bookMetaDataRepository = bookMetaDataRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<ResponseDto> Handle(BookStatusCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var bookStatus = request.IsAccepted ? BookStatus.Accepted : BookStatus.Rejected;
            _bookMetaDataRepository.ChangeBookStatus(request.BookId, bookStatus);
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
                Message = "Error occured during changing book status!",
                StatusCode = 400
            };
        }
    }
}