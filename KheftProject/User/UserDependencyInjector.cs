using FluentValidation;
using KheftProject.Core.DependencyInjection.Abstraction;
using KheftProject.User.Business.Contracts.Commands;
using KheftProject.User.Business.Validators;
using KheftProject.User.DataAccess.Repositories;
using KheftProject.User.DataAccess.Repositories.Abstraction;

namespace KheftProject.User;

public class UserDependencyInjector : IDependencyInstaller
{
    public void Install(IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IUserRepository, UserRepository>();
        serviceCollection.AddSingleton<IValidator<UserRegistrationCommand>, UserRegistrationCommandValidator>();
    }
}