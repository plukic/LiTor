using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiTor.Core.Authorization;

/// <summary>
/// Defines all predefined roles
/// </summary>
public static class RoleSeedData
{
  public static IEnumerable<Role> GetSeedData()
  {
    return new[]
    {
      new Role(ApplicationRoles.Admin){
        IsActive=true
      },
    };
  }
}
