using LiTor.Web.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace LiTor.Web.Controllers;

public class AppBaseController : Controller
{

  protected IActionResult RedirectToReturnUrl(string returnUrl)
  {
    if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
    {
      return Redirect(returnUrl);
    }

    return Redirect("~/");
  }
  protected IActionResult RedirectToPreviousUrl() => Redirect(Url.GetRefererOrFallback());


}
