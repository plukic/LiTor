namespace ITO.Extensions.Datatables.Paging;
public class PagingRequestBaseDto
{
  public int PageSize { get; set; }
  public int Skip { get; set; }
  public int Draw { get; set; }
}
