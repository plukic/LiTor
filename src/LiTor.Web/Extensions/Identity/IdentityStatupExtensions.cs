using LiTor.Core.Authorization;
using LiTor.Infrastructure.Data;
using LiTor.Web.Configuration;
using LiTor.Web.Infrastructure.Security;
using Ardalis.GuardClauses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Identity;

namespace LiTor.Web.Extensions.Identity;

public static class IdentityStatupExtensions
{


  public static IServiceCollection AddConfiguredIdentity(this IServiceCollection services, IConfiguration configuration)
  {
    services.AddIdentity<User, Role>()
                 .AddEntityFrameworkStores<AppDbContext>()
                 //.AddErrorDescriber<IdentityLocalizedErrorDescriber>()
                 .AddClaimsPrincipalFactory<AppClaimsPrincipalFactory>()
                 .AddDefaultTokenProviders();

    //services.AddIdentityPasswordGenerator();

    services.Configure<IdentityOptions>(options =>
    {
      options.Password.RequiredLength = 8;
      options.User.RequireUniqueEmail = false;
      options.SignIn.RequireConfirmedEmail = true;
      // By default confirmed account means that email is confirmed
      // Since this is same as RequireConfirmedEmail we will set it to false
      // (https://github.com/dotnet/aspnetcore/blob/master/src/Identity/Extensions.Core/src/DefaultUserConfirmation.cs)
      options.SignIn.RequireConfirmedAccount = false;
      options.SignIn.RequireConfirmedPhoneNumber = false;
    });

    // Set token expiration to 3 hours
    services.Configure<DataProtectionTokenProviderOptions>(options =>
    {
      options.TokenLifespan = TimeSpan.FromHours(3);
    });

    services.ConfigureApplicationCookie(options =>
    {
      options.Cookie.Name = CookieNames.Authentication;
      options.Cookie.HttpOnly = CookieAuthenticationDefaults.HttpOnly;
      // Set expiration to 5 years.
      // This is neccessary only for location management role.
      options.ExpireTimeSpan = TimeSpan.FromDays(365 * 5);
      options.AccessDeniedPath = CookieAuthenticationDefaults.AccessDeniedPath;
      options.LoginPath = CookieAuthenticationDefaults.LoginPath;
      options.LogoutPath = CookieAuthenticationDefaults.LogoutPath;
      options.SlidingExpiration = CookieAuthenticationDefaults.SlidingExpiration;

      // Override default behavior of redirect to login handler
      // See: https://github.com/dotnet/aspnetcore/blob/master/src/Security/Authentication/Cookies/src/CookieAuthenticationEvents.cs
      options.Events.OnRedirectToLogin = context =>
      {
        //// Similiar to original but we will remove return url for ajax requests.
        //// Since we redirect to return url on successful login, we do not want to return previous partial content
        //if (context.Request.IsAjaxRequest())
        //{
        //  context.RedirectUri = context.RedirectUri.RemoveQueryString("returnUrl");
        //  context.Response.Headers[HeaderNames.Location] = context.RedirectUri;
        //  context.Response.StatusCode = StatusCodes.Status401Unauthorized;
        //}
        //else
        //{
        context.Response.Redirect(context.RedirectUri);
        //}
        return Task.CompletedTask;
      };
    });

    return services;

  }



  public static IServiceCollection AddConfiguredAuthorization(this IServiceCollection services, IConfiguration configuration)
  {
    // For now we only require user to be authenticated
    services.AddAuthorization(conf =>
    {
      conf.FallbackPolicy = new AuthorizationPolicyBuilder() // Mimics global AuthorizeAttribute
              .RequireAuthenticatedUser()
              .Build();
    });

    return services;
  }

  public static IServiceCollection AddConfiguredDataProtection(this IServiceCollection services)
  {
    services.AddDataProtection()
        .PersistKeysToDbContext<AppDbContext>();

    return services;
  }

}
