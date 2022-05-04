using Microsoft.AspNetCore.Mvc;

namespace LiTor.Web.Components;

public class NavigationMenu : ViewComponent
{
  public async Task<IViewComponentResult> InvokeAsync()
  {
    return View();
  }
}
