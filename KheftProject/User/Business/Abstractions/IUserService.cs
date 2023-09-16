using KheftProject.User.Business.Contracts.Dtos;
using KheftProject.User.DataAccess.Entities;

namespace KheftProject.User.Business.Abstractions;

internal interface IUserService
{
    Task<bool> HasUserWithTelegramId(long telegramSerialId);
    Task<Guid> GetOrCreateUser(UserDto userEntity);
}