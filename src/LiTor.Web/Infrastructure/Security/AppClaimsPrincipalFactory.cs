using LiTor.Core.Authorization;
using LiTor.Core.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System.Security.Claims;

namespace LiTor.Web.Infrastructure.Security
{
  /// <summary>
  /// Extends predefined claims
  /// <see cref="https://github.com/dotnet/aspnetcore/blob/master/src/Identity/Extensions.Core/src/UserClaimsPrincipalFactory.cs"/>
  /// </summary>
  public class AppClaimsPrincipalFactory : UserClaimsPrincipalFactory<User, Role>
  {
    public AppClaimsPrincipalFactory(UserManager<User> userManager,
        RoleManager<Role> roleManager,
        IOptions<IdentityOptions> options)
        : base(userManager, roleManager, options)
    {
    }

    /// <summary>
    /// Overrides default claims factory. This will be invoked only once per user login.
    /// </summary>
    public override async Task<ClaimsPrincipal> CreateAsync(User user)
    {
      // Generate principal with base claims
      var principal = await base.CreateAsync(user);
      var claims = new List<Claim>();

      if (user.FirstName.IsNotNullOrEmpty() && user.LastName.IsNotNullOrEmpty())
      {
        claims.Add(new Claim(AppClaimTypes.Name, $"{user.FirstName} {user.LastName}"));
      }
      ((ClaimsIdentity)principal.Identity).AddClaims(claims);
      return principal;
    }
  }
}
