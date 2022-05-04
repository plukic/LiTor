
using LiTor.Core.Features.UserManagement;
using LiTor.Infrastructure.Caching;
using LiTor.Infrastructure.Data;
using LiTor.Infrastructure.Features.UserManagement;
using LiTor.SharedKernel.Caching;
using LiTor.SharedKernel.Interfaces;
using Autofac;
using MediatR;
using MediatR.Pipeline;
using System.Reflection;
using Module = Autofac.Module;

namespace LiTor.Infrastructure
{
  public class DefaultInfrastructureModule : Module
  {
    private readonly bool _isDevelopment = false;
    private readonly List<Assembly> _assemblies = new List<Assembly>();

    public DefaultInfrastructureModule(bool isDevelopment, Assembly? callingAssembly = null)
    {
      _isDevelopment = isDevelopment;
      var coreAssembly = Assembly.GetAssembly(typeof(AssemblyTarget));
      // TODO: Replace "Project" with any type from your Core project
      var infrastructureAssembly = Assembly.GetAssembly(typeof(StartupSetup));
      if (coreAssembly != null)
      {
        _assemblies.Add(coreAssembly);
      }
      if (infrastructureAssembly != null)
      {
        _assemblies.Add(infrastructureAssembly);
      }
      if (callingAssembly != null)
      {
        _assemblies.Add(callingAssembly);
      }
    }

    protected override void Load(ContainerBuilder builder)
    {
      if (_isDevelopment)
      {
        RegisterDevelopmentOnlyDependencies(builder);
      }
      else
      {
        RegisterProductionOnlyDependencies(builder);
      }
      RegisterCommonDependencies(builder);
      RegisterMediator(builder);
    }

    private void RegisterMediator(ContainerBuilder builder)
    {
      builder
              .RegisterType<Mediator>()
              .As<IMediator>()
              .InstancePerLifetimeScope();

      builder.Register<ServiceFactory>(context =>
      {
        var c = context.Resolve<IComponentContext>();
        return t => c.Resolve(t);
      });

      var mediatrOpenTypes = new[]
      {
                typeof(IRequestHandler<,>),
                typeof(IRequestExceptionHandler<,,>),
                typeof(IRequestExceptionAction<,>),
                typeof(INotificationHandler<>),
            };

      foreach (var mediatrOpenType in mediatrOpenTypes)
      {
        builder
        .RegisterAssemblyTypes(_assemblies.ToArray())
        .AsClosedTypesOf(mediatrOpenType)
        .AsImplementedInterfaces();
      }
    }

    private void RegisterCommonDependencies(ContainerBuilder builder)
    {
      builder.RegisterGeneric(typeof(EfRepository<>))
          .As(typeof(IRepository<>))
          .As(typeof(IReadRepository<>))
          .InstancePerLifetimeScope();

      builder.RegisterType<UserService>().As<IUserService>().InstancePerLifetimeScope();
      builder.RegisterType<DistributedCacheAccessor>().As<ICacheAccessor>().InstancePerLifetimeScope();
    }
    private void RegisterDevelopmentOnlyDependencies(ContainerBuilder builder)
    {
    }
    private void RegisterProductionOnlyDependencies(ContainerBuilder builder)
    {
    }

  }
}
