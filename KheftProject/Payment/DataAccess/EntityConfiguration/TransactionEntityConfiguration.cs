using KheftProject.Payment.DataAccess.Entities;
using KheftProject.Payment.DataAccess.Entities.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KheftProject.Payment.DataAccess.EntityConfiguration;

public class TransactionEntityConfiguration : IEntityTypeConfiguration<TransactionEntity>
{
    public void Configure(EntityTypeBuilder<TransactionEntity> builder)
    {
        builder.HasKey(x => x.TransactionId);
        builder.HasAlternateKey(x => x.BankTransactionRefId);
        builder.HasOne(x => x.Book)
            .WithOne()
            .HasForeignKey<TransactionEntity>(x => x.BookId);
        builder.Property(x => x.Status)
            .HasConversion(t => t.ToString(),
                t => (TransactionStatus)Enum.Parse(typeof(TransactionStatus), t));
    }
}