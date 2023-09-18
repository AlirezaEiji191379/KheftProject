using KheftProject.Core.Contexts;
using MediatR;

namespace KheftProject.Payment.Business.Contracts.Commands;

public class PayBookCommand : IRequest<ResponseDto>
{
    public Guid BookId { get; init; }
    public decimal Price { get; init; }
}