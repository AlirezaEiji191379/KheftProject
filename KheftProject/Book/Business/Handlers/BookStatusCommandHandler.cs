using KheftProject.Book.Business.Contracts.Commands;
using KheftProject.Book.Business.Contracts.Dtos;
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
            if (request.IsAccepted)
            {
                var acceptedBookMetaDataEntity = await _bookMetaDataRepository.GetBookMetaDataEntityIncludeBookAndOwner(request.BookId);
                var accpetedBookDto = new AcceptBookResponse
                {
                    Book = new BookDto
                    {
                        Description = acceptedBookMetaDataEntity.BookEntity.Description,
                        Id = acceptedBookMetaDataEntity.BookId,
                        IsAccepted = true,
                        Name = acceptedBookMetaDataEntity.BookEntity.BookName
                    },
                    BookOwner = new Owner
                    {
                        FullName = acceptedBookMetaDataEntity.BookEntity.Owner.FullName,
                        TelegramSerialId = acceptedBookMetaDataEntity.BookEntity.Owner.TelegramSerialId,
                        TelegramUsername = acceptedBookMetaDataEntity.TelegramUserName
                    }
                };
                return new ResponseDto
                {
                    Message = accpetedBookDto,
                    StatusCode = 200
                };
            }
            return new ResponseDto()
            {
                Message = "book rejected!",
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