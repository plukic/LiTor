using LiTor.Web.Configuration;
using LiTor.Web.Infrastructure.Cookies;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;

namespace LiTor.Web.Controllers;

public class LanguageController : AppBaseController
{
  private readonly ICookieManager _cookieManager;

  public LanguageController(
      ICookieManager cookieManager) 
  {
    _cookieManager = cookieManager;
  }

  /// <summary>
  /// Set current language
  /// </summary>
  /// <param name="culture">Language code</param>
  [HttpPost]
  public IActionResult SetLanguage(string culture)
  {


    // Add culture to cookie
    _cookieManager.Append<string>(
        CookieNames.Culture,
        CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)));

    return RedirectToPreviousUrl();
  }
}
