
using LiTor.SharedKernel;

namespace LiTor.Core.Localization.Domain;
/// <summary>
/// Represents entity translation per field
/// </summary>
public class LocalizedProperty : BaseEntity<int>
{
  public int EntityId { get; set; }
  public int LanguageId { get; set; }
  public string LocaleKeyGroup { get; set; }
  public string LocaleKey { get; set; }
  public string LocaleValue { get; set; }
  public Language Language { get; set; }
}

