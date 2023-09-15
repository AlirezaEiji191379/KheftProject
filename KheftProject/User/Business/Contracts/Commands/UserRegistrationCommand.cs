using KheftProject.Core.Contexts;
using MediatR;

namespace KheftProject.User.Business.Contracts.Commands;

public class UserRegistrationCommand : IRequest<ResponseDto>
{
    public Guid UserId { get; set; }
    public string TelegramUsername { get; set; }
    public string? PhoneNumber { get; set; }
    public string? FullName { get; set; }
}