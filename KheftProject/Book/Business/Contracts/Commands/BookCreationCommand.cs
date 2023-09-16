using KheftProject.Core.Contexts;
using MediatR;

namespace KheftProject.Book.Business.Contracts.Commands;

public class BookCreationCommand : IRequest<ResponseDto>
{
    public string BookName { get; init; }
    public decimal Price { get; init; }
    public string? Description { get; init; }
    public Guid OwnerId { get; init; }
}