using KheftProject.Book.DataAccess.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KheftProject.Book.DataAccess.EntityConfiguration;

public class BookEntityConfiguration : IEntityTypeConfiguration<BookEntity>
{
    public void Configure(EntityTypeBuilder<BookEntity> builder)
    {
        builder.HasKey(bookEntity => bookEntity.BookId);
        builder.HasOne(bookEntity => bookEntity.Owner)
            .WithMany()
            .HasForeignKey(x => x.OwnerId);
    }
    
}