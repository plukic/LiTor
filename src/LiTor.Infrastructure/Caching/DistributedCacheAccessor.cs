using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using LiTor.SharedKernel.Caching;
using Ardalis.Result;
using Microsoft.Extensions.Caching.Distributed;

namespace LiTor.Infrastructure.Caching;
public class DistributedCacheAccessor : ICacheAccessor
{
  private readonly IDistributedCache _cache;

  public DistributedCacheAccessor(IDistributedCache cache)
  {
    _cache = cache;
  }

  public Result<T> Get<T>(string key)
  {
    var value = _cache.GetString(key);
    if (value == null)
      return Result<T>.NotFound();
    return TryParse<T>(value);
  }

  private Result<T> TryParse<T>(string jsonValue)
  {
    try
    {
      var objectValue = JsonSerializer.Deserialize<T>(jsonValue);
      return Result<T>.Success(objectValue);
    }
    catch (Exception ex)
    {
      return Result<T>.Error(ex.Message);
    }
  }

  private string Serialize<T>(T key)
  {
    return JsonSerializer.Serialize(key);
  }

  public async Task<Result<T>> GetAsync<T>(string key)
  {
    var jsonString = await _cache.GetStringAsync(key);
    if (jsonString.IsNullOrEmpty())
      return Result<T>.NotFound();
    return TryParse<T>(jsonString);
  }
  public Task RefreshAsync(string key)
  {
    return _cache.RefreshAsync(key);
  }

  public void Set<T>(string key, T value)
  {
    _cache.SetString(key, Serialize(value));
  }
  public Task SetAsync<T>(string key, T value)
  {
    return _cache.SetStringAsync(key, Serialize(value));
  }
}
