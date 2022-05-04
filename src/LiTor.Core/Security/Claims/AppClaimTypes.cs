using System.Security.Claims;

namespace LiTor.Core.Security.Claims;
public class AppClaimTypes
{
  public const string Name = "full_name";
  public const string Location = "loc";
  public const string Email = ClaimTypes.Email;
  public const string UserName = ClaimTypes.Name;
  public const string UserId = ClaimTypes.NameIdentifier;
  public const string Role = ClaimTypes.Role;
}
