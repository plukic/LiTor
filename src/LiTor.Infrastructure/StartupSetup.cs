using LiTor.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LiTor.Infrastructure
{
  public static class StartupSetup
  {
    public static IServiceCollection AddDbContext(this IServiceCollection services,
      IConfiguration configuration, bool isDevEnvironment)
    {
      var connectionString = configuration.GetConnectionString(nameof(AppDbContext));

      services.AddDbContext<AppDbContext>(options =>
      {
        options.UseSqlServer(connectionString);

        if (isDevEnvironment)
        {
          options.EnableDetailedErrors(true);
          options.EnableSensitiveDataLogging(true);
        }
      });
      return services;
    }
  }
}
