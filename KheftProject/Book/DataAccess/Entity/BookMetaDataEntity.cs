using KheftProject.Book.DataAccess.Entity.Enums;

namespace KheftProject.Book.DataAccess.Entity;

public class BookMetaDataEntity
{
    public Guid BookId { get; set; }
    public BookEntity BookEntity { get; set; }
    
    public string TelegramUserName { get; set; }
    public DateTime CreatedAt { get; set; }
    public BookStatus BookStatus { get; set; }
    
}