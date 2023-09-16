using KheftProject.Core.Contexts;
using MediatR;

namespace KheftProject.Book.Business.Contracts.Commands;

public class BookAcceptCommand : IRequest<ResponseDto>
{
    public Guid BookId { get; init; }
}