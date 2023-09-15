using System.Reflection;
using KheftProject.Core.DataAccess;
using KheftProject.Core.DependencyInjection.Abstraction;
using Microsoft.EntityFrameworkCore;

namespace KheftProject.Core.DependencyInjection;

public static class KheftDependencyInjector
{
    public static void AddKheftServices(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        var dependencyInstallers = GetDependencyInstallerImplementors();
        dependencyInstallers.ToList().ForEach(installer =>
        {
            installer.Install(serviceCollection);
        });
        serviceCollection.AddDbContext<KheftDbContext>
        (options =>
            options.UseNpgsql(configuration.GetConnectionString("KheftDB")));
        serviceCollection.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
    }


    private static IEnumerable<IDependencyInstaller> GetDependencyInstallerImplementors()
    {
        return typeof(IAssemblyMarkerInterface)
            .Assembly
            .DefinedTypes
            .Where(type => !type.IsAbstract && !type.IsInterface && type.IsAssignableTo(typeof(IDependencyInstaller)))
            .Select(Activator.CreateInstance)
            .Cast<IDependencyInstaller>();
    }

}