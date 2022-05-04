using LiTor.Core.Authorization;
using LiTor.Core.Localization.Domain;
using Ardalis.EFCore.Extensions;
using Microsoft.AspNetCore.DataProtection.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LiTor.Infrastructure.Data
{
  public class AppDbContext : IdentityDbContext<User, Role, string, UserClaim, UserRole, UserLogin, RoleClaim, UserToken>, IDataProtectionKeyContext
  {
    public DbSet<DataProtectionKey> DataProtectionKeys { get; set; }
    public DbSet<Language> Languages { get; set; }
    public DbSet<LocalizedProperty> LocalizedProperties { get; set; }

    public AppDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);
      modelBuilder.ApplyAllConfigurationsFromCurrentAssembly();

    }
  }
}
