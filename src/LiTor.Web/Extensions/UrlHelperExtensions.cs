using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;

namespace LiTor.Web.Extensions;

/// <summary>
/// Extension methods for <see cref="IUrlHelper"/>
/// </summary>
public static partial class UrlHelperExtensions
{
  public static string GetHomeUrl(this IUrlHelper urlHelper)
      => urlHelper.Content("~/");

  public static string GetReferer(this IUrlHelper urlHelper)
      => GetRefererInternal(urlHelper);

  public static string GetRefererOrFallback(this IUrlHelper urlHelper)
      => GetRefererOrFallback(urlHelper, null, null);

  public static string GetRefererOrFallback(this IUrlHelper urlHelper, string route)
      => GetRefererOrFallback(urlHelper, route, null);

  public static string GetRefererOrFallback(this IUrlHelper urlHelper, string route, object values)
  {
    if (urlHelper == null)
    {
      throw new ArgumentNullException(nameof(urlHelper));
    }

    var referer = GetRefererInternal(urlHelper);

    if (string.IsNullOrEmpty(referer))
    {
      return string.IsNullOrEmpty(route) ?
              urlHelper.Content("~/") :
              urlHelper.RouteUrl(route, values);
    }

    return referer;
  }

  private static string GetRefererInternal(this IUrlHelper urlHelper)
  {
    if (urlHelper is null)
    {
      throw new ArgumentNullException(nameof(urlHelper));
    }

    var referer = urlHelper.ActionContext.HttpContext.Request.Headers[HeaderNames.Referer].FirstOrDefault();

    if (!string.IsNullOrEmpty(referer))
    {
      var url = new Uri(referer);

      if (urlHelper.IsLocalUrl(url.AbsolutePath))
      {
        return referer;
      }
    }

    return null;
  }
}
