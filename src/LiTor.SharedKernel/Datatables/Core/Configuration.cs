namespace ITO.Extensions.Datatables.Core;
public static class Configuration
{
  /// <summary>
  /// Get's DataTables.AspNet runtime options for server-side processing.
  /// </summary>
  public static IDataTablesOptions Options { get; set; }

  /// <summary>
  /// Static constructor.
  /// Set's default configuration for DataTables.AspNet.
  /// </summary>
  static Configuration()
  {
    Options = new DataTablesOptions();
  }
}
