using Microsoft.AspNetCore.Identity;
namespace LiTor.Core.Authorization;
public class User : IdentityUser
{
  #region Scalar properties

  public bool IsActive { get; set; }
  public bool IsDeleted { get; set; }

  public string FirstName { get; set; }
  public string LastName { get; set; }
  public DateTime CreationDateUtc { get; set; }
  public DateTime? LastUpdateDateUtc { get; set; }
  #endregion Scalar properties

  #region Navigation properties
  

  public ICollection<UserClaim> Claims { get; set; }
  public ICollection<UserLogin> Logins { get; set; }
  public ICollection<UserToken> Tokens { get; set; }
  public ICollection<UserRole> UserRoles { get; set; }
  public ICollection<UserRefreshToken> UserRefreshTokens { get; set; }
  #endregion Navigation properties
}

public static class UserConst
{
  public const int MaxFirstNameLength = 255;
  public const int MaxLastNameLength = 255;
  public const int MaxUserNameLength = 256;
  public const int MaxEmailLength = 256;
}
