using KheftProject.Book.DataAccess.Entity;
using KheftProject.Payment.DataAccess.Entities.Enums;

namespace KheftProject.Payment.DataAccess.Entities;

public class TransactionEntity
{
    public Guid TransactionId { get; set; }
    public long BankTransactionRefId { get; set; }
    public decimal Amount { get; set; }
    public TransactionStatus Status { get; set; }
    public DateTime CreatedAt { get; set; } 
    public Guid BookId { get; set; }
    public BookEntity Book { get; set; }
}