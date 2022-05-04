using LiTor.Core.Localization;
using LiTor.Web.Configuration;
using Microsoft.AspNetCore.Localization;

namespace LiTor.Web.Extensions;

public static class LocalizationStartupExtensions
{
  public static IServiceCollection AddConfiguredLocalization(this IServiceCollection services)
  {
    services.AddPortableObjectLocalization(options => options.ResourcesPath = "Infrastructure/Localization/Resources");
    services.Configure<RequestLocalizationOptions>(options =>
    {
      var supportedCultures = LocalizationConfig.GetSupportedCultures().ToList();

      options.SupportedCultures = supportedCultures;
      options.SupportedUICultures = supportedCultures;
      options.DefaultRequestCulture = new RequestCulture(LocalizationConfig.GetDefaultCulture());
      options.FallBackToParentCultures = true;
      options.FallBackToParentUICultures = true;

      // Set cookie name for cookie provider
      var cookieProvider = options.RequestCultureProviders.OfType<CookieRequestCultureProvider>().First();

      cookieProvider.CookieName = CookieNames.Culture;

      // Remove all culture providers so we can only use cookie localization
      // Remove this code if query string and language header providers are also used
      options.RequestCultureProviders.Clear();
      options.RequestCultureProviders.Add(cookieProvider);
    });

    return services;
  }
}
