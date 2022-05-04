using LiTor.Core.Localization.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LiTor.Infrastructure.Data.Config.Localization;

public class LocalizedPropertyConfiguration : IEntityTypeConfiguration<LocalizedProperty>
  {
      public void Configure(EntityTypeBuilder<LocalizedProperty> builder)
      {
          builder.ToTable(nameof(LocalizedProperty));
          builder.HasKey(p => p.Id);
      }
  }
