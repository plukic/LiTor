using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiTor.Core.Security.Claims;

namespace System.Security.Claims
{
  public static class ClaimsPrincipalExtensions
  {
    public static string? GetUserId(this ClaimsPrincipal principal)
    {
      var claim = principal.FindFirst(AppClaimTypes.UserId);

      return claim?.Value;
    }

    public static string? GetUserName(this ClaimsPrincipal principal)
    {
      var claim = principal.FindFirst(AppClaimTypes.UserName);

      return claim?.Value;
    }

    public static IEnumerable<string> GetRoles(this ClaimsPrincipal principal)
    {
      var claims = principal.FindAll(AppClaimTypes.Role).Select(s => s.Value);

      return claims ?? Enumerable.Empty<string>();
    }

    /// <summary>
    /// Checks if current principal is in one of the passed roles.
    /// </summary>
    /// <param name="principal">Current principal</param>
    /// <param name="roles">Roles</param>
    /// <returns>Is in role status</returns>
    public static bool IsInRoleAny(this ClaimsPrincipal principal, params string[] roles) =>
        roles.Any(r => principal.IsInRole(r));
  }
}
