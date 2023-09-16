using KheftProject.User.Business.Abstractions;
using KheftProject.User.Business.Contracts.Dtos;
using KheftProject.User.Facade.Abstractions;

namespace KheftProject.User.Facade;

internal class UserFacade : IUserFacade
{
    private readonly IUserService _userService;

    public UserFacade(IUserService userService)
    {
        _userService = userService;
    }

    public Task<bool> HasUserWithTelegramId(long telegramSerialId)
    {
        return _userService.HasUserWithTelegramId(telegramSerialId);
    }

    public Task<Guid> GetOrCreateUser(UserDto userDto)
    {
        return _userService.GetOrCreateUser(userDto);
    }

}