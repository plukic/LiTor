using LiTor.Core.Localization.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LiTor.Infrastructure.Data.Config.Localization;
public class LanguageConfiguration : IEntityTypeConfiguration<Language>
{
  public void Configure(EntityTypeBuilder<Language> builder)
  {
    builder.ToTable(nameof(Language));
    builder.HasKey(p => p.Id);
    builder.Property(b => b.Name).IsRequired().HasMaxLength(LanguageConst.MaxNameLen);
    builder.Property(b => b.NameNormalized).IsRequired().HasMaxLength(LanguageConst.MaxNameLen);
    builder.Property(b => b.Code).IsRequired().HasMaxLength(LanguageConst.MaxCodeLen);
    builder.Property(b => b.CodeNormalized).IsRequired().HasMaxLength(LanguageConst.MaxCodeLen);
    builder.Property(b => b.Ordering).IsRequired();
    builder.Property(b => b.IconImageName).IsRequired(false).HasMaxLength(LanguageConst.MaxIconImageNameLen);
    builder.Property(b => b.IsDefault).IsRequired().HasDefaultValue(false);
    builder.Property(b => b.IsDeleted).IsRequired().HasDefaultValue(false);

    builder.HasMany(b => b.LocalizedProperties)
        .WithOne(b => b.Language)
        .HasForeignKey(b => b.LanguageId)
        .IsRequired();
  }
}
