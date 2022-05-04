using LiTor.Core.Localization;
using Ardalis.Result;
using Microsoft.AspNetCore.Localization;

namespace LiTor.Web.Infrastructure.Localization;

/// <summary>
/// Web implementation for current language accessor
/// </summary>
public class WebCurrentLanguageAccessor : ICurrentLanguageAccessor
{
  /// <summary>
  /// Per scope cache value
  /// </summary>
  private LanguageDto? _currentLanguage;

  private readonly ILanguageService _languageService;
  private readonly IHttpContextAccessor _httpContextAccessor;

  public WebCurrentLanguageAccessor(ILanguageService languageService, IHttpContextAccessor httpContextAccessor)
  {
    _languageService = languageService;
    _httpContextAccessor = httpContextAccessor;
  }

  public async Task<LanguageDto> GetCurrentLanguageAsync()
  {
    if (_currentLanguage != null)
    {
      return _currentLanguage;
    }

    var cultureFeature = _httpContextAccessor.HttpContext!.Features.Get<IRequestCultureFeature>();
    Result<LanguageDto> languageResult;

    // Culture may be null if cookie is not set
    if (cultureFeature != null)
    {
      var culture = cultureFeature.RequestCulture.Culture.Name;

      languageResult = await _languageService.GetByCodeAsync(culture);

      if (languageResult.IsSuccess)
      {
        _currentLanguage = languageResult.Value;

        return _currentLanguage;
      }
    }

    // If language not present in cookie, fetch default from database
    languageResult = await _languageService.GetDefaultAsync();

    if (languageResult.IsSuccess)
    {
      _currentLanguage = languageResult.Value;

      return _currentLanguage;
    }

    throw new Exception("Current language not found.");
  }
}
