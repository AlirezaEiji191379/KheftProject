namespace KheftProject.Core.DependencyInjection.Abstraction;

public interface IDependencyInstaller
{
    void Install(IServiceCollection services);
}