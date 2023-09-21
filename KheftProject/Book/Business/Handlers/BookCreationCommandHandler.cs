using FluentValidation;
using KheftProject.Book.Business.Contracts.Commands;
using KheftProject.Book.DataAccess.Entity;
using KheftProject.Book.DataAccess.Entity.Enums;
using KheftProject.Book.DataAccess.Repositories.Abstractions;
using KheftProject.Core.Contexts;
using KheftProject.Core.DataAccess.Repository.Abstraction;
using KheftProject.User.Business.Contracts.Dtos;
using KheftProject.User.Facade.Abstractions;
using MediatR;

namespace KheftProject.Book.Business.Handlers;

internal class BookCreationCommandHandler : IRequestHandler<BookCreationCommand, ResponseDto>
{
    private readonly IBookRepository _bookRepository;
    private readonly IBookMetaDataRepository _bookMetaDataRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IValidator<BookCreationCommand> _validator;
    private readonly IUserFacade _userFacade;
    
    public BookCreationCommandHandler(IBookRepository bookRepository,
        IUnitOfWork unitOfWork,
        IValidator<BookCreationCommand> validator,
        IUserFacade userFacade, 
        IBookMetaDataRepository bookMetaDataRepository)
    {
        _bookRepository = bookRepository;
        _unitOfWork = unitOfWork;
        _validator = validator;
        _userFacade = userFacade;
        _bookMetaDataRepository = bookMetaDataRepository;
    }

    public async Task<ResponseDto> Handle(BookCreationCommand request, CancellationToken cancellationToken)
    {
        await using var transaction = await _unitOfWork.BeginTransactionAsync();
        try
        {
            await _validator.ValidateAndThrowAsync(request, cancellationToken);
            var ownerId = await _userFacade.GetOrCreateUser(new UserDto()
            {
                FullName = request.BookOwner.FullName,
                TelegramSerialId = request.BookOwner.TelegramSerialId
            });
            var bookEntity = new BookEntity
            {
                Description = request.Description,
                OwnerId = ownerId,
                BookName = request.BookName,
                Price = request.Price,
                BookId = Guid.NewGuid()
            };
            var bookMetaDataEntity = new BookMetaDataEntity()
            {
                BookEntity = bookEntity,
                BookId = bookEntity.BookId,
                BookStatus = BookStatus.Pending,
                CreatedAt = DateTime.Now.ToUniversalTime(),
                TelegramUserName = request.BookOwner.TelegramUsername
            };
            await _bookRepository.Create(bookEntity);
            await _bookMetaDataRepository.Create(bookMetaDataEntity); 
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            await transaction.CommitAsync(cancellationToken);
            return new ResponseDto()
            {
                StatusCode = 201,
                Message = bookEntity.BookId
            };
        }
        catch (Exception exception)
        {
            await transaction.RollbackAsync(cancellationToken);
            return new ResponseDto()
            {
                StatusCode = 400,
                Message = "Error was occured during adding the book to the system! try later!"
            };
        }
    }
}