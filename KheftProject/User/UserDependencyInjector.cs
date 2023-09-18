using KheftProject.Core.DependencyInjection.Abstraction;
using KheftProject.User.Business.Abstractions;
using KheftProject.User.Business.Services;
using KheftProject.User.DataAccess.Repositories;
using KheftProject.User.DataAccess.Repositories.Abstraction;
using KheftProject.User.Facade;
using KheftProject.User.Facade.Abstractions;

namespace KheftProject.User;

public class UserDependencyInjector : IDependencyInstaller
{
    public void Install(IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IUserFacade, UserFacade>();
    }
}