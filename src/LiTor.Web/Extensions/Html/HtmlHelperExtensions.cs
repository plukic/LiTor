using Ardalis.GuardClauses;
using Microsoft.AspNetCore.Html;

namespace Microsoft.AspNetCore.Mvc.Rendering
{
  public static partial class HtmlHelperExtensions
  {

    public static string AddAttributeIf(this IHtmlHelper htmlHelper,
        bool condition,
        string name,
        string value) => condition ? @$"{name}=""{value}""" : null;

    /// <summary>
    /// Applies given class if condition is satisfied
    /// </summary>
    public static string AddClassIf(this IHtmlHelper htmlHelper, bool condition, string cssClass)
        => condition ? cssClass : null;

    public static string ApplyClassIf(this IHtmlHelper htmlHelper, bool condition, string cssClassTrue, string cssClassFalse)
        => condition ? cssClassTrue : cssClassFalse;

    public static HtmlString GetStatusIcon(this IHtmlHelper htmlHelper, bool status)
    {
      Guard.Against.Null(htmlHelper, nameof(htmlHelper));

      return status ?
          new HtmlString(@"<i class=""fa fa-check text-success""></i>") :
          new HtmlString(@"<i class=""fa fa-times text-danger""></i>");
    }

    public static string GetDifficultyRangeClass(this IHtmlHelper htmlHelper, int value)
    {
      Guard.Against.Null(htmlHelper, nameof(htmlHelper));

      return value switch
      {
        >= 1 and <= 2 => "success",
        >= 3 and <= 3 => "warning",
        > 3 => "danger",
        _ => "primary"
      };
    }
  }
}
