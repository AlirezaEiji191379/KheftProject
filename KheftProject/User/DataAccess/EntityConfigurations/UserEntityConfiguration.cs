using KheftProject.User.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KheftProject.User.DataAccess.EntityConfigurations;

public class UserEntityConfiguration : IEntityTypeConfiguration<UserEntity>
{
    public void Configure(EntityTypeBuilder<UserEntity> builder)
    {
        builder.HasKey(userEntity => userEntity.UserId);
        builder.HasIndex(userEntity => userEntity.TelegramSerialId).IsUnique();
    }
}