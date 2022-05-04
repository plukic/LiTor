
using ITO.Extensions.Datatables.Core;
using ITO.Extensions.Datatables.Paging;
using ITO.Extensions.Datatables.Sorting;

namespace ITO.Extensions.Web.Datatables.Web;

  /// <summary>
  /// Provides extension methods for DataTables response creation.
  /// </summary>
  public static class DataTablesExtensions
  {

      /// <summary>
      /// Creates a DataTables response object.
      /// </summary>
      /// <param name="request">The DataTables request object.</param>
      /// <param name="errorMessage">Error message to send back to client-side.</param>
      /// <returns>A DataTables response object.</returns>
      public static IDataTablesResponse CreateResponse(this IDataTablesRequest request, string errorMessage)
      {
          return request.CreateResponse(errorMessage, null);
      }
      /// <summary>
      /// Creates a DataTables response object.
      /// </summary>
      /// <param name="request">The DataTables request object.</param>
      /// <param name="errorMessage">Error message to send back to client-side.</param>
      /// <param name="additionalParameters">Aditional parameters dictionary.</param>
      /// <returns>A DataTables response object.</returns>
      public static IDataTablesResponse CreateResponse(this IDataTablesRequest request, string errorMessage, IDictionary<string, object> additionalParameters)
      {
          return DataTablesResponse.Create(request, errorMessage, additionalParameters);
      }
      /// <summary>
      /// Creates a DataTables response object.
      /// </summary>
      /// <param name="request">The DataTables request object.</param>
      /// <param name="totalRecords">Total records count (total available non-filtered records on database).</param>
      /// <param name="totalRecordsFiltered">Total filtered records (total available records after filtering).</param>
      /// <param name="data">Data object (collection).</param>
      /// <returns>A DataTables response object.</returns>
      public static IDataTablesResponse CreateResponse(this IDataTablesRequest request, int totalRecords, int totalRecordsFiltered, object data)
      {
          return request.CreateResponse(totalRecords, totalRecordsFiltered, data, null);
      }
      /// <summary>
      /// Creates a DataTables response object.
      /// </summary>
      /// <param name="request">The DataTables request object.</param>
      /// <param name="totalRecords">Total records count (total available non-filtered records on database).</param>
      /// <param name="totalRecordsFiltered">Total filtered records (total available records after filtering).</param>
      /// <param name="data">Data object (collection).</param>
      /// <param name="additionalParameters">Adicional parameters dictionary.</param>
      /// <returns>A DataTables response object.</returns>
      public static IDataTablesResponse CreateResponse(this IDataTablesRequest request, int totalRecords, int totalRecordsFiltered, object data, IDictionary<string, object> additionalParameters)
      {
          return DataTablesResponse.Create(request, totalRecords, totalRecordsFiltered, data, additionalParameters);
      }

  public static List<SortColumn> GetSortColumns(this IDataTablesRequest request)
  {
    return request.Columns.Where(x => x.IsSortable && x.Sort != null)
        .OrderBy(x => x.Sort.Order)
        .Select(x => new SortColumn
        {
          ColumnName = x.Field,
          Direction = x.Sort.Direction 
        }).ToList();
  }

  public static PagingRequestBaseDto GetPagingData(this IDataTablesRequest request)
  {
    return new PagingRequestBaseDto
    {
      PageSize = request.Length,
      Skip = request.Start,
      Draw = request.Draw,
    };
  }
}
