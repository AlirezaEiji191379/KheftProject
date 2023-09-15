using Microsoft.EntityFrameworkCore;

namespace KheftProject.Core.DataAccess;

public static class Migrator
{
    public static async Task Migrate(WebApplication app)
    {
        using var service = app.Services.CreateScope();
        var dbContext = service.ServiceProvider.GetService<KheftDbContext>();
        var pendingMigrations = await dbContext.Database.GetPendingMigrationsAsync();
        if (pendingMigrations.Any())
        {
            Console.WriteLine("Applying pending migrations to the Database...");
            await dbContext.Database.MigrateAsync();
        }
        Console.WriteLine("Database Migrations Are Up to date!");
    }
}