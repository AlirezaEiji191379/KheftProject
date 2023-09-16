using FluentValidation;
using KheftProject.Book.Business.Contracts.Commands;
using KheftProject.Book.DataAccess.Entity;
using KheftProject.Book.DataAccess.Entity.Enums;
using KheftProject.Book.DataAccess.Repositories.Abstractions;
using KheftProject.Core.Contexts;
using KheftProject.Core.DataAccess.Repository.Abstraction;
using MediatR;

namespace KheftProject.Book.Business.Handlers;

internal class BookCreationCommandHandler : IRequestHandler<BookCreationCommand, ResponseDto>
{
    private readonly IBookRepository _bookRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IValidator<BookCreationCommand> _validator;

    public BookCreationCommandHandler(IBookRepository bookRepository,
        IUnitOfWork unitOfWork,
        IValidator<BookCreationCommand> validator)
    {
        _bookRepository = bookRepository;
        _unitOfWork = unitOfWork;
        _validator = validator;
    }

    public async Task<ResponseDto> Handle(BookCreationCommand request, CancellationToken cancellationToken)
    {
        try
        {
            await _validator.ValidateAndThrowAsync(request, cancellationToken);
            var bookEntity = new BookEntity
            {
                Description = request.Description,
                OwnerId = request.OwnerId,
                BookName = request.BookName,
                Price = request.Price,
                BookStatus = BookStatus.NotPaid
            };
            await _bookRepository.Create(bookEntity);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return new ResponseDto()
            {
                StatusCode = 201,
                Message = bookEntity.BookId
            };
        }
        catch (Exception exception)
        {
            return new ResponseDto()
            {
                StatusCode = 400,
                Message = exception.Message
            };
        }
    }
}