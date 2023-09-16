using KheftProject.Core.DataAccess;
using KheftProject.Core.DataAccess.Repository;
using KheftProject.User.DataAccess.Entities;
using KheftProject.User.DataAccess.Repositories.Abstraction;
using Microsoft.EntityFrameworkCore;

namespace KheftProject.User.DataAccess.Repositories;

public class UserRepository : BaseRepository<UserEntity>, IUserRepository
{
    private readonly KheftDbContext _dbContext;
    public UserRepository(KheftDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<bool> HasUserWithTelegramSerialId(long telegramSerialId)
    {
        return _dbContext.Users.AnyAsync(x => x.TelegramSerialId == telegramSerialId);
    }

    public Task<UserEntity?> FindUserByTelegramSerialId(long telegramSerialId)
    {
        return _dbContext.Users.Where(x => x.TelegramSerialId == telegramSerialId).SingleOrDefaultAsync();
    }
}