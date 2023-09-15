using KheftProject.Core.DataAccess.Repository;
using KheftProject.Core.DataAccess.Repository.Abstraction;
using KheftProject.Core.DependencyInjection.Abstraction;
using Microsoft.EntityFrameworkCore;

namespace KheftProject.Core.DataAccess;

public class DataLayerDependencyInjector : IDependencyInstaller
{
    private readonly IConfiguration _configuration;

    public DataLayerDependencyInjector(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public void Install(IServiceCollection serviceCollection)
    {
        serviceCollection.AddDbContext<KheftDbContext>
        (options =>
            options.UseNpgsql(_configuration.GetConnectionString("KheftDB")));
        serviceCollection.AddScoped<IUnitOfWork, UnitOfWork>();
    }
}