using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace LiTor.Core.Authorization
{
  public class Role : IdentityRole
  {
    #region Ctor

    public Role()
    {
    }

    public Role(string name) : base(name)
    {
    }

    #endregion Ctor


    public bool IsActive { get; set; }


    #region Navigation properties


    public ICollection<UserRole> UserRoles { get; set; }
    public ICollection<RoleClaim> RoleClaims { get; set; }

    #endregion Navigation properties
  }
}
