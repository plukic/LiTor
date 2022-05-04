using LiTor.Core.Localization;

namespace LiTor.Web.Components;

public class LanguageMenuViewModel
{
  public string CurrentCulture { get; set; }
  public LanguageDto CurrentLanguage { get; set; }

  public IReadOnlyCollection<LanguageDto> Languages { get; set; }
}
