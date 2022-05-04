using LiTor.Core.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LiTor.Infrastructure.Config.Authorization;

public class UserClaimConfiguration : IEntityTypeConfiguration<UserClaim>
{
  public void Configure(EntityTypeBuilder<UserClaim> builder)
  {
    builder.ToTable(nameof(UserClaim));
    builder.HasKey(x => x.Id);
    builder.HasOne(x => x.User).WithMany(x => x.Claims).HasForeignKey(x => x.UserId).IsRequired();
  }
}
