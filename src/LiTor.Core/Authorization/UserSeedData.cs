using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiTor.SharedKernel;

namespace LiTor.Core.Authorization;
/// <summary>
/// Defines all predefined user accounts
/// </summary>
public static class UserSeedData
{
  public static IEnumerable<UserSeed> GetSeedData()
  {
    return new[]
    {
     new UserSeed
     {
         User = new User
         {
             Id = DefaultGuidGenerator.Instance.Generate().ToString(),
             Email = "admin@admin.com",
             LockoutEnabled = false,
             UserName = "admin@admin.com",
             EmailConfirmed = true,
             PhoneNumberConfirmed = true,
             IsActive = true,
             CreationDateUtc=DateTime.UtcNow,
             FirstName="Admin",
             LastUpdateDateUtc=DateTime.UtcNow,
             PhoneNumber="063000000",
             LastName="Admin",
             IsDeleted=false,
         },
         Roles = new [] { new Role(ApplicationRoles.Admin) }
     }
    };
  }
}

public class UserSeed
{
  public UserSeed()
  {
    Roles = Array.Empty<Role>();
  }
  public User User { get; set; }
  public IEnumerable<Role> Roles { get; set; }
}
