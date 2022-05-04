using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiTor.SharedKernel;

namespace LiTor.Core.Localization.Domain;
/// <summary>
/// This model will not be mapped to database since we do not use db localization.
/// For now it is used for
/// </summary>
public class Language : BaseEntity<int>
{
  public Language()
  {
    LocalizedProperties = new HashSet<LocalizedProperty>();
  }
  public Language(string name, string code, string iconImageName, bool isDefault)
          : this()
  {
    Name = name;
    Code = code;
    IconImageName = iconImageName;
    IsDefault = isDefault;
  }
  public string Name { get; set; }
  public string NameNormalized { get; set; }
  public string Code { get; set; }
  public string CodeNormalized { get; set; }

  public int Ordering { get; set; }
  public string IconImageName { get; set; }
  public bool IsDefault { get; set; }
  public bool IsDeleted { get; set; }

  public ICollection<LocalizedProperty> LocalizedProperties { get; set; }
}

public static class LanguageConst
{
  public const int MaxNameLen = 100;
  public const int MaxCodeLen = 15;
  public const int MaxIconImageNameLen = 50;
}
