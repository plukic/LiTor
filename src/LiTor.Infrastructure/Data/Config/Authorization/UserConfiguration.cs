using LiTor.Core.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LiTor.Infrastructure.Config.Authorization;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
  public void Configure(EntityTypeBuilder<User> builder)
  {
    builder.ToTable(nameof(User));
    builder.Property(p => p.FirstName).IsRequired(false).HasMaxLength(UserConst.MaxFirstNameLength);
    builder.Property(p => p.LastName).IsRequired(false).HasMaxLength(UserConst.MaxLastNameLength);
    builder.Property(p => p.IsActive).IsRequired().HasDefaultValue(false);
    builder.Property(p => p.PhoneNumber).IsRequired(false);

    #region Identity config

    //By default Identity doesn't provide navigation properties, so manual configuration is required
    builder.HasMany(u => u.Claims).WithOne(c => c.User).HasForeignKey(uc => uc.UserId).IsRequired();
    builder.HasMany(u => u.Logins).WithOne(c => c.User).HasForeignKey(uc => uc.UserId).IsRequired();
    builder.HasMany(u => u.Tokens).WithOne(c => c.User).HasForeignKey(uc => uc.UserId).IsRequired();
    builder.HasMany(u => u.UserRoles).WithOne(c => c.User).HasForeignKey(uc => uc.UserId).IsRequired();
    builder.HasMany(u => u.UserRefreshTokens).WithOne(c => c.User).HasForeignKey(uc => uc.UserId).IsRequired();
    #endregion Identity config
  }
}
