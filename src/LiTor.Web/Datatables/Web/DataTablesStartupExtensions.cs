using ITO.Extensions.Datatables.Core;
using ITO.Extensions.Web.Datatables.Web;
using Microsoft.AspNetCore.Mvc.ModelBinding;
namespace LiTor.Web.Datatables.Web;
public static class DataTablesStartupExtensions
{

  /// <summary>
  /// Provides DataTables.AspNet registration for AspNet5 projects.
  /// </summary>
  /// <param name="services">Service collection for dependency injection.</param>
  public static void RegisterDataTables(this IServiceCollection services) { services.RegisterDataTables(new DataTablesOptions()); }

  /// <summary>
  /// Provides DataTables.AspNet registration for AspNet5 projects.
  /// </summary>
  /// <param name="services">Service collection for dependency injection.</param>
  /// <param name="options">DataTables.AspNet options.</param>
  public static void RegisterDataTables(this IServiceCollection services, IDataTablesOptions options) { services.RegisterDataTables(options, new ModelBinder()); }

  /// <summary>
  /// Provides DataTables.AspNet registration for AspNet5 projects.
  /// </summary>
  /// <param name="services">Service collection for dependency injection.</param>
  /// <param name="requestModelBinder">Request model binder to use when resolving 'IDataTablesRequest' models.</param>
  public static void RegisterDataTables(this IServiceCollection services, ModelBinder requestModelBinder) { services.RegisterDataTables(new DataTablesOptions(), requestModelBinder); }

  /// <summary>
  /// Provides DataTables.AspNet registration for AspNet5 projects.
  /// </summary>
  /// <param name="services">Service collection for dependency injection.</param>
  /// <param name="parseRequestAdditionalParameters">Function to evaluante and parse aditional parameters sent within the request (user-defined parameters).</param>
  /// <param name="parseResponseAdditionalParameters">Indicates whether response aditional parameters parsing is enabled or not.</param>
  public static void RegisterDataTables(this IServiceCollection services, Func<ModelBindingContext, IDictionary<string, object>> parseRequestAdditionalParameters, bool parseResponseAdditionalParameters) { services.RegisterDataTables(new DataTablesOptions(), new ModelBinder(), parseRequestAdditionalParameters, parseResponseAdditionalParameters); }

  /// <summary>
  /// Provides DataTables.AspNet registration for AspNet5 projects.
  /// </summary>
  /// <param name="options">DataTables.AspNet options.</param>
  /// <param name="requestModelBinder">Model binder to use when resolving 'IDataTablesRequest' model.</param>
  public static void RegisterDataTables(this IServiceCollection services, IDataTablesOptions options, ModelBinder requestModelBinder) { services.RegisterDataTables(options, requestModelBinder, null, false); }

  /// <summary>
  /// Provides DataTables.AspNet registration for AspNet5 projects.
  /// </summary>
  /// <param name="services">Service collection for dependency injection.</param>
  /// <param name="options">DataTables.AspNet options.</param>
  /// <param name="requestModelBinder">Request model binder to use when resolving 'IDataTablesRequest' models.</param>
  /// <param name="parseRequestAdditionalParameters">Function to evaluate and parse aditional parameters sent within the request (user-defined parameters).</param>
  /// <param name="enableResponseAdditionalParameters">Indicates whether response aditional parameters parsing is enabled or not.</param>
  public static void RegisterDataTables(this IServiceCollection services, 
    IDataTablesOptions options,
    ModelBinder requestModelBinder, 
    Func<ModelBindingContext, IDictionary<string, object>> parseRequestAdditionalParameters, 
    bool enableResponseAdditionalParameters)
  {
    if (options == null) throw new ArgumentNullException("options", "Options for DataTables.AspNet cannot be null.");
    if (requestModelBinder == null) throw new ArgumentNullException("requestModelBinder", "Request model binder for DataTables.AspNet cannot be null.");

    ITO.Extensions.Datatables.Core.Configuration.Options = options;

    if (parseRequestAdditionalParameters != null)
    {
      ITO.Extensions.Datatables.Core.Configuration.Options.EnableRequestAdditionalParameters();
      requestModelBinder.ParseAdditionalParameters = parseRequestAdditionalParameters;
    }

    if (enableResponseAdditionalParameters)
      ITO.Extensions.Datatables.Core.Configuration.Options.EnableResponseAdditionalParameters();

    services.Configure<Microsoft.AspNetCore.Mvc.MvcOptions>(_options =>
    {
      // Should be inserted into first position because there is a generic binder which could end up resolving/binding model incorrectly.
      _options.ModelBinderProviders.Insert(0, new ModelBinderProvider(requestModelBinder));
    });
  }
}
