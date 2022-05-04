using LiTor.Web.Configuration;

namespace LiTor.Web.Extensions.AntiForgery;

public static class AntyForgeryTokenExtensions
{
  /// <summary>
  /// Antiforgery token configuration
  /// </summary>
  public static IServiceCollection AddConfiguredAntiforgery(this IServiceCollection services)
  {
    services.AddAntiforgery(options =>
    {
      options.Cookie.Name = CookieNames.AntiforgeryToken;
      options.FormFieldName = $"{CookieNames.AntiforgeryToken}-FORM";
      options.HeaderName = $"{CookieNames.AntiforgeryToken}-TOKEN";
    });

    return services;
  }
}
