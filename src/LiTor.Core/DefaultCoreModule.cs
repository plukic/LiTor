using LiTor.Core.Localization;
using LiTor.SharedKernel;
using LiTor.SharedKernel.TextNormalizers;
using Autofac;

namespace LiTor.Core
{
  public class DefaultCoreModule : Module
  {
    protected override void Load(ContainerBuilder builder)
    {
      builder.RegisterType<DefaultGuidGenerator>().As<IGuidGenerator>().InstancePerLifetimeScope();
      builder.RegisterType<UppercaseTextNormalizer>().As<ITextNormalizer>().SingleInstance();
      builder.RegisterType<LanguageService>().As<ILanguageService>().InstancePerLifetimeScope();
    }
  }
}
