using KheftProject.Core.DependencyInjection.Abstraction;

namespace KheftProject.Core.DependencyInjection;

public static class KheftDependencyInjector
{
    public static void AddKheftServices(this IServiceCollection serviceCollection)
    {
        var dependencyInstallers = GetDependencyInstallerImplementors();
        dependencyInstallers.ToList().ForEach(installer =>
        {
            installer.Install(serviceCollection);
        });
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