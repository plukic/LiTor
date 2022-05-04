using LiTor.Core.Security.Users;
using LiTor.SharedKernel;
using Redah.Web.Infrastructure.Security.Claims;

namespace LiTor.Web.Extensions.CurrentPrincipal;

public  static class CurrentPrincipalStartupExceptions
{

  public static IServiceCollection AddHttpContextCurrentPrincipalAccessor(this IServiceCollection services)
  {
    services
        .AddScoped<ICurrentUser, CurrentUser>()
        .AddSingleton<ICurrentPrincipalAccessor, HttpContextCurrentPrincipalAccessor>();

    return services;
  }
}
