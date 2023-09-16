using KheftProject.Core.Contexts;
using MediatR;

namespace KheftProject.User.Business.Contracts.Commands;

public class UserRegistrationCommand : IRequest<ResponseDto>
{
    public string TelegramUsername { get; init; }
    public string FullName { get; init; }
    public long TelegramSerialId { get; init; }
}