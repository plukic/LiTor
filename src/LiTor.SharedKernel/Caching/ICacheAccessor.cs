using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ardalis.Result;

namespace LiTor.SharedKernel.Caching;
public interface ICacheAccessor
{
  public Result<T> Get<T>(string key);
  public Task<Result<T>> GetAsync<T>(string key);

  public void Set<T>(string key,T value);
  public Task SetAsync<T>(string key, T value);
  Task RefreshAsync(string key);
}
