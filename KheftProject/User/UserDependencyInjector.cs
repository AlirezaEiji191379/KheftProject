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
    public void Install(IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IUserRepository, UserRepository>();
        serviceCollection.AddScoped<IUserService, UserService>();
        serviceCollection.AddScoped<IUserFacade, UserFacade>();
    }
}