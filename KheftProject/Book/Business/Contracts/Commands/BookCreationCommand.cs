using KheftProject.Core.Contexts;
using MediatR;

namespace KheftProject.Book.Business.Contracts.Commands;

public class BookCreationCommand : IRequest<ResponseDto>
{
    public string BookName { get; init; }
    public decimal Price { get; init; }
    public string Description { get; init; }
    public BookOwner BookOwner { get; init; }
}

public class BookOwner
{
    public string TelegramUsername { get; init; }
    public string FullName { get; init; }
    public long TelegramSerialId { get; init; }
}

