using KheftProject.User.Business.Contracts.Dtos;

namespace KheftProject.User.Facade.Abstractions;

public interface IUserFacade
{
    Task<bool> HasUserWithTelegramId(long telegramSerialId);
    Task<Guid> GetOrCreateUser(UserDto userDto);
}