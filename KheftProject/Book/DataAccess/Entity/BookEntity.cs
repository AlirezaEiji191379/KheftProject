using KheftProject.Book.DataAccess.Entity.Enums;
using KheftProject.User.DataAccess.Entities;

namespace KheftProject.Book.DataAccess.Entity;

public class BookEntity
{
    public Guid BookId { get; set; }
    public string BookName { get; set; }
    public decimal Price { get; set; }
    public string? Description { get; set; }
    public BookStatus BookStatus { get; set; }
    
    public Guid OwnerId { get; set; }
    public UserEntity Owner { get; set; }
}