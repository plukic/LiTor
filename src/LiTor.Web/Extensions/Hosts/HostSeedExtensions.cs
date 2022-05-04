using LiTor.Core.Authorization;
using LiTor.Infrastructure;
using LiTor.Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using Serilog;

namespace LiTor.Web.Extensions.Hosts;

public static class HostSeedExtensions
{
  public static IHost RunDatabaseSeed(this IHost host, bool isDevelopmentEnvironment)
  {
    if (!isDevelopmentEnvironment)
      return host;
    
    using var scope = host.Services.CreateScope();
    try
    {
      Log.Information("Starting database initialization.");
      var context = scope.ServiceProvider.GetService<AppDbContext>();
      var userManager = scope.ServiceProvider.GetService<UserManager<User>>();
      var roleManager = scope.ServiceProvider.GetService<RoleManager<Role>>();

      DatabaseInitializer.Initialize(context, userManager, roleManager).Wait();
    }
    catch (Exception ex)
    {
      Log.Fatal(ex, "An error occured while seeding the database.");
    }

    return host;

  }
}
