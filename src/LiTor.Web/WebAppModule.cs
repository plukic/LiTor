using LiTor.Core.Localization;
using LiTor.Web.Configuration;
using LiTor.Web.Infrastructure.Cookies;
using LiTor.Web.Infrastructure.Localization;
using Autofac;
namespace LiTor.Web;
public class WebAppModule : Module
{

  private readonly IConfiguration _configuration;

  public WebAppModule(IConfiguration configuration)
  {
    _configuration = configuration;
  }

  protected override void Load(ContainerBuilder builder)
  {
    WebAppConfiguration webAppConfiguration = new WebAppConfiguration();
    _configuration.GetSection(nameof(WebAppConfiguration)).Bind(webAppConfiguration);
    builder.RegisterInstance(webAppConfiguration).SingleInstance();


    builder.RegisterType<WebCurrentLanguageAccessor>().As<ICurrentLanguageAccessor>().InstancePerLifetimeScope();
    builder.RegisterType<CookieManager>().As<ICookieManager>().InstancePerLifetimeScope();
  }
}
