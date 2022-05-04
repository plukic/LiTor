using LiTor.Core;
using LiTor.Infrastructure;
using LiTor.Web;
using LiTor.Web.Configuration;
using LiTor.Web.Datatables.Web;
using LiTor.Web.Extensions;
using LiTor.Web.Extensions.AntiForgery;
using LiTor.Web.Extensions.CurrentPrincipal;
using LiTor.Web.Extensions.Hosts;
using LiTor.Web.Extensions.Identity;
using Ardalis.ListStartupServices;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

#region App Configuration Providers
builder.Host.ConfigureAppConfiguration(cfg =>
{
  cfg.AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", false);
  cfg.AddJsonFile($"appsettings.connectionstrings.json", false);
  cfg.AddUserSecrets<Program>();
});

#endregion

#region Serilog
builder.Host.UseSerilog((_, config) => config.ReadFrom.Configuration(builder.Configuration));
#endregion


#region MVC Configuration
builder.Services.AddControllersWithViews()
  .AddNewtonsoftJson()
  .AddViewLocalization()
  .AddCookieTempDataProvider(options => options.Cookie.Name = CookieNames.TempData)
  .AddDataAnnotationsLocalization();

//builder.Services.Configure<CookiePolicyOptions>(options =>
//{
//  options.CheckConsentNeeded = context => false;
//  options.MinimumSameSitePolicy = SameSiteMode.None;
//});
#endregion


#region Runtime Services Configuration
builder.Services.AddDbContext(builder.Configuration, builder.Environment.EnvironmentName == Environments.Development);
builder.Services.AddConfiguredIdentity(builder.Configuration);
builder.Services.AddConfiguredAuthorization(builder.Configuration);
builder.Services.AddConfiguredDataProtection();
builder.Services.AddConfiguredLocalization();
builder.Services.AddHttpContextCurrentPrincipalAccessor();
builder.Services.AddConfiguredAntiforgery();
builder.Services.AddDistributedMemoryCache();
#endregion


#region Datatables
builder.Services.RegisterDataTables();
#endregion

#region DI Services List & Diagnostic
// add list services for diagnostic purposes - see https://github.com/ardalis/AspNetCoreStartupServices
builder.Services.Configure<ServiceConfig>(config =>
{
  config.Services = new List<ServiceDescriptor>(builder.Services);
  config.Path = "/listservices";
});

#endregion

#region Service Provider Container
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
{
  containerBuilder.RegisterModule(new DefaultCoreModule());
  containerBuilder.RegisterModule(new DefaultInfrastructureModule(builder.Environment.EnvironmentName == Environments.Development));
  containerBuilder.RegisterModule(new WebAppModule(builder.Configuration));
});
#endregion






var app = builder.Build();
if (app.Environment.IsDevelopment())
{
  app.UseDeveloperExceptionPage();
  app.UseShowAllServicesMiddleware();
}
else
{
  app.UseExceptionHandler("/Home/Error");
  app.UseHsts();
}
app.UseRouting();
app.UseRequestLocalization();
app.UseStaticFiles();

app.UseAuthentication();
app.UseAuthorization();

app.UseHttpsRedirection();
app.UseCookiePolicy();
app.UseEndpoints(endpoints =>
{
  endpoints.MapDefaultControllerRoute();
});

app.RunDatabaseSeed(builder.Environment.EnvironmentName== Environments.Development).Run();
