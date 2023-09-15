using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace KheftProject.Core.DataAccess;

public class KheftDbContext : DbContext
{
    public KheftDbContext(DbContextOptions options) : base(options)
    { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}