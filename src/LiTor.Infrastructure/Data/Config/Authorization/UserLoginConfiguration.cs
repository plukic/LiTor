using LiTor.Core.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace LiTor.Infrastructure.Config.Authorization;

public class UserLoginConfiguration : IEntityTypeConfiguration<UserLogin>
{
  public void Configure(EntityTypeBuilder<UserLogin> builder)
  {
    builder.ToTable(nameof(UserLogin));
    builder.HasOne(x => x.User).WithMany(x => x.Logins).HasForeignKey(x => x.UserId).IsRequired();

  }
}
