using KheftProject.Core.DataAccess;
using KheftProject.Core.DataAccess.Repository;
using KheftProject.User.DataAccess.Entities;
using KheftProject.User.DataAccess.Repositories.Abstraction;

namespace KheftProject.User.DataAccess.Repositories;

public class UserRepository : BaseRepository<UserEntity>, IUserRepository
{
    public UserRepository(KheftDbContext dbContext) : base(dbContext)
    {
    }
}