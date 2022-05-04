using LiTor.Core.Features.Licensing;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LiTor.Web.Controllers
{
  /// <summary>
  /// A sample MVC controller that uses views.
  /// Razor Pages provides a better way to manage view-based content, since the behavior, viewmodel, and view are all in one place,
  /// rather than spread between 3 different folders in your Web project. Look in /Pages to see examples.
  /// See: https://ardalis.com/aspnet-core-razor-pages-%E2%80%93-worth-checking-out/
  /// </summary>
  public class HomeController : Controller
  {

    private readonly IMediator _mediator;

    public HomeController(IMediator mediator)
    {
      _mediator = mediator;
    }

    public IActionResult Index()
    {
      return View();
    }

    public async Task<IActionResult> Test()
    {
      var licenseResponse = await _mediator.Send(new CreateLicenseRequest
      {
        PassPhrase = "Petar Testira"
      });
      return Json(new
      {
        licenseResponse.PrivateKey,
        licenseResponse.PassPhrase,
        licenseResponse.PublicKey,
        licenseResponse.LicenseContent,
      });
    }
    [AllowAnonymous]
    public IActionResult Error()
    {
      return View();
    }
  }
}
