

using LiTor.Core.Authorization;
using LiTor.Infrastructure.Data;
using Ardalis.GuardClauses;
using Microsoft.AspNetCore.Identity;

namespace LiTor.Infrastructure;
public class DatabaseInitializer
{
  public static async Task Initialize(
     AppDbContext context,
     UserManager<User> userManager,
     RoleManager<Role> roleManager)
  {
    Guard.Against.Null(context, nameof(context));
    Guard.Against.Null(userManager, nameof(userManager));
    Guard.Against.Null(roleManager, nameof(roleManager));

    await SeedApplicationRoles(roleManager);
    await  SeedApplicationUsers(userManager);
  }



  private static async Task SeedApplicationRoles(RoleManager<Role> roleManager)
  {
    foreach (var role in RoleSeedData.GetSeedData())
    {
      if (!roleManager.RoleExistsAsync(role.Name).Result)
      {
        await roleManager.CreateAsync(role);
      }
    }
  }
  private static async Task SeedApplicationUsers(UserManager<User> userManager)
  {
    foreach (var userSeed in UserSeedData.GetSeedData())
    {
      if (userManager.FindByEmailAsync(userSeed.User.Email).Result == null)
      {
        await userManager.CreateAsync(userSeed.User);
        await userManager.AddToRolesAsync(userSeed.User, userSeed.Roles.Select(s => s.Name));
        await userManager.AddPasswordAsync(userSeed.User, "Password!1");
      }
    }
  }
}
