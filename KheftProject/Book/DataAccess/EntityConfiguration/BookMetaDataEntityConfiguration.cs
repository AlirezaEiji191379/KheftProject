using KheftProject.Book.DataAccess.Entity;
using KheftProject.Book.DataAccess.Entity.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KheftProject.Book.DataAccess.EntityConfiguration;

public class BookMetaDataEntityConfiguration : IEntityTypeConfiguration<BookMetaDataEntity>
{
    public void Configure(EntityTypeBuilder<BookMetaDataEntity> builder)
    {
        builder.HasKey(x => x.BookId);
        builder.HasOne(x => x.BookEntity)
            .WithOne()
            .HasForeignKey<BookMetaDataEntity>(x => x.BookId);
        builder.Property(x => x.BookStatus)
            .HasConversion(t => t.ToString(),
                t => (BookStatus)Enum.Parse(typeof(BookStatus), t));
    }
}