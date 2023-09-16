using KheftProject.Core.DataAccess.Repository.Abstraction;
using KheftProject.User.DataAccess.Entities;

namespace KheftProject.User.DataAccess.Repositories.Abstraction;

internal interface IUserRepository : IBaseRepository<UserEntity>
{
    Task<bool> HasUserWithTelegramSerialId(long telegramSerialId);
    Task<UserEntity?> FindUserByTelegramSerialId(long telegramSerialId);
}