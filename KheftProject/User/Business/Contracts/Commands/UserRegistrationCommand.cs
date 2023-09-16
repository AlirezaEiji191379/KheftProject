using KheftProject.Core.Contexts;
using MediatR;

namespace KheftProject.User.Business.Contracts.Commands;

public class UserRegistrationCommand : IRequest<ResponseDto>
{
    public Guid UserId { get; init; }
    public string TelegramUsername { get; init; }
    public string? PhoneNumber { get; init; }
    public string? FullName { get; init; }
}