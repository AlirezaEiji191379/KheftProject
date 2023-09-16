namespace KheftProject.User.DataAccess.Entities;

public class UserEntity
{
    public Guid UserId { get; set; }
    public long TelegramSerialId { get; set; }
    public string TelegramUsername { get; set; }
    public string? FullName { get; set; }
}