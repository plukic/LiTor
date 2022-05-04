using ITO.Extensions.Datatables.NameConvention;

namespace ITO.Extensions.Datatables.Core;

  public interface IDataTablesOptions
  {
      /// <summary>
      /// Gets the default page length.
      /// </summary>
      int DefaultPageLength { get; }
      /// <summary>
      /// Gets the indicator whether draw validation is enabled or not.
      /// </summary>
      bool IsDrawValidationEnabled { get; }
      /// <summary>
      /// Gets the indicator whether aditional request parameters parsing is enabled or not.
      /// </summary>
      bool IsRequestAdditionalParametersEnabled { get; }
      /// <summary>
      /// Gets the indicator whether aditional response parameters parsing is enabled or not.
      /// </summary>
      bool IsResponseAdditionalParametersEnabled { get; }


      /// <summary>
      /// Gets request name conventions.
      /// </summary>
      IRequestNameConvention RequestNameConvention { get; }
      /// <summary>
      /// Gets response name conventions.
      /// </summary>
      IResponseNameConvention ResponseNameConvention { get; }



      /// <summary>
      /// Sets default page length.
      /// </summary>
      /// <param name="defaultPageLength">Default page length to use.</param>
      /// <returns></returns>
      IDataTablesOptions SetDefaultPageLength(int defaultPageLength);
      /// <summary>
      /// Enables draw validation.
      /// Draw validation is enabled by default.
      /// </summary>
      /// <returns></returns>
      IDataTablesOptions EnableDrawValidation();
      /// <summary>
      /// Disables draw validation.
      /// </summary>
      /// <returns></returns>
      IDataTablesOptions DisableDrawValidation();
      /// <summary>
      /// Enables request aditional parameter parsing.
      /// You must also provide your own custom parsing function on registration.
      /// </summary>
      /// <returns></returns>
      IDataTablesOptions EnableRequestAdditionalParameters();
      /// <summary>
      /// Disables request aditional parameter parsing.
      /// </summary>
      /// <returns></returns>
      IDataTablesOptions DisableRequestAdditionalParameters();
      /// <summary>
      /// Enables response aditional parameter parsing.
      /// </summary>
      /// <returns></returns>
      IDataTablesOptions EnableResponseAdditionalParameters();
      /// <summary>
      /// Disables response aditional parameter parsing.
      /// </summary>
      /// <returns></returns>
      IDataTablesOptions DisableResponseAdditionalParameters();
      /// <summary>
      /// Forces DataTables to use CamelCase naming convention.
      /// CamelCase is enabled by default.
      /// </summary>
      /// <returns></returns>
      IDataTablesOptions UseCamelCase();
      /// <summary>
      /// Forces DataTables to use HungarianNotation naming convention.
      /// HungarianNotation is available for compatibility with older DataTables (prior to 1.10).
      /// </summary>
      /// <returns></returns>
      IDataTablesOptions UseHungarianNotation();
  }
