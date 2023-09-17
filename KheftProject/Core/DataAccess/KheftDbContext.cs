using System.Reflection;
using KheftProject.Book.DataAccess.Entity;
using KheftProject.Payment.DataAccess.Entities;
using KheftProject.User.DataAccess.Entities;
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

    public DbSet<UserEntity> Users { get; set; }
    public DbSet<BookEntity> Books { get; set; }
    public DbSet<BookMetaDataEntity> BookMetaData { get; set; }
    public DbSet<TransactionEntity> Transactions { get; set; }
}