using Ardalis.GuardClauses;

namespace LiTor.Web.Infrastructure.Cookies;

/// <summary>
/// Default cookie management implementation
/// </summary>
public class CookieManager : ICookieManager
{
  /// <summary>
  /// Default cookie options
  /// TODO: Make configurable at startup
  /// </summary>
  private static readonly CookieOptions _options = new()
  {
    HttpOnly = true,
    IsEssential = false,
    Secure = true,
    //SameSite = SameSiteMode.Strict,
    Expires = DateTimeOffset.UtcNow.AddYears(5)
  };

  private readonly IHttpContextAccessor _httpContextAccessor;

  public CookieManager(IHttpContextAccessor httpContextAccessor)
  {
    _httpContextAccessor = httpContextAccessor;
  }

  public void Append<T>(string name, T value, CookieOptions? options = null) where T : IConvertible
  {
    Guard.Against.NullOrEmpty(name, nameof(name));

    _httpContextAccessor.HttpContext!.Response.Cookies.Append(
       name,
       value.To<string>(),
       options ?? _options);
  }

  public void Delete(string name) => _httpContextAccessor.HttpContext!.Response.Cookies.Delete(name);

  public string? Get(string name) => GetValue(name);

  public T? Get<T>(string name) where T : struct
  {
    var value = GetValue(name);

    return value?.To<T>();
  }

  private string? GetValue(string name) =>
      _httpContextAccessor.HttpContext!.Request.Cookies[name];
}
