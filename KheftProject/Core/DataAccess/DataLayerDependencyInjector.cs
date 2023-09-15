using KheftProject.Core.DataAccess.Repository;
using KheftProject.Core.DataAccess.Repository.Abstraction;
using KheftProject.Core.DependencyInjection.Abstraction;

namespace KheftProject.Core.DataAccess;

public class DataLayerDependencyInjector : IDependencyInstaller
{
    public void Install(IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IUnitOfWork, UnitOfWork>();
    }
}