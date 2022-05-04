using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using LiTor.Core.Authorization;

namespace LiTor.Infrastructure.Config.Authorization;

public class UserRefreshTokenConfiguration : IEntityTypeConfiguration<UserRefreshToken>
{
  public void Configure(EntityTypeBuilder<UserRefreshToken> builder)
  {
    builder.ToTable(nameof(UserRefreshToken));
    builder.HasKey(b => b.Id);
    builder.Property(b => b.CreationDateTimeUtc).IsRequired();
    builder.Property(b => b.ExpirationDateTimeUtc).IsRequired();

    builder.HasOne(x => x.User).WithMany(x => x.UserRefreshTokens).HasForeignKey(x => x.UserId).IsRequired();

  }
}
