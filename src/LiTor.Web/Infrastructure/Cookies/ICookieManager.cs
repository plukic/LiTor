namespace LiTor.Web.Infrastructure.Cookies;

/// <summary>
/// Abstractions for cookies management
/// </summary>
public interface ICookieManager
{
  void Append<T>(string name, T value, CookieOptions? options = null) where T : IConvertible;

  string? Get(string name);

  T? Get<T>(string name) where T : struct;

  void Delete(string name);
}
