using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiTor.Core.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LiTor.Infrastructure.Data.Config.Authorization;
public class RoleClaimConfiguration : IEntityTypeConfiguration<RoleClaim>
{
  public void Configure(EntityTypeBuilder<RoleClaim> builder)
  {
    builder.ToTable(nameof(RoleClaim));
    builder.HasOne(x=>x.Role).WithMany(x=>x.RoleClaims).HasForeignKey(x=>x.RoleId).IsRequired();
  }
}
