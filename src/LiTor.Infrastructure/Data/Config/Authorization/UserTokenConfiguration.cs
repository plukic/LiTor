using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using LiTor.Core.Authorization;

namespace LiTor.Infrastructure.Config.Authorization;

public class UserTokenConfiguration : IEntityTypeConfiguration<UserToken>
{
  public void Configure(EntityTypeBuilder<UserToken> builder)
  {
    builder.ToTable(nameof(UserToken));
    builder.HasOne(x => x.User).WithMany(x => x.Tokens).HasForeignKey(x => x.UserId).IsRequired();

  }
}
