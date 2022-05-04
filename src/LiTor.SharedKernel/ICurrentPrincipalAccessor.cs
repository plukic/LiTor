
using System.Security.Claims;

namespace LiTor.SharedKernel;
/// <summary>
/// Abstraction for current request <see cref="System.Security.Claims.ClaimsPrincipal"/>
/// </summary>
public interface ICurrentPrincipalAccessor
{
  ClaimsPrincipal Principal { get; }
}
