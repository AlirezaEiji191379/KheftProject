using KheftProject.Core.Contexts;
using MediatR;

namespace KheftProject.Book.Business.Contracts.Commands;

public class BookStatusCommand : IRequest<ResponseDto>
{
    public Guid BookId { get; init; }
    public bool IsAccepted { get; init; }
}