using LiTor.Core.Authorization;
using LiTor.Core.Features.UserManagement;
using LiTor.Core.Localization;
using LiTor.Web.Extensions;
using LiTor.Web.Models.Account;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using System.Threading.Tasks;

namespace LiTor.Web.Controllers
{
  /// <summary>
  /// Account controller
  /// </summary>
  public class AccountController : AppBaseController
  {
    private readonly IUserService _userService;
    private readonly SignInManager<User> _signInManager;
    private readonly IStringLocalizer<AccountController> _localizer;

    public AccountController(
        IUserService userService,
        SignInManager<User> signInManager,
        IStringLocalizer<AccountController> localizer)
    {
      _userService = userService;
      _signInManager = signInManager;
      _localizer = localizer;
    }

    [HttpGet]
    [AllowAnonymous]
    public IActionResult SignIn(string returnUrl)
    {
      var model = new AccountSignInViewModel
      {
        ReturnUrl = returnUrl ?? Url.Content("~/")
      };

      return View("SignIn", model);
    }

    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> SignIn(AccountSignInViewModel model)
    {
      if (!ModelState.IsValid)
      {
        return View(model);
      }

      var user = await _userService.GetByNameAsync(model.Username);

      if (!IsValidUserAccount(user))
      {
        return View(model);
      }

      // Check if user requires/has confirmed account
      // Sign in does not check email/phone confirmation separately
      if (!await _signInManager.CanSignInAsync(user))
      {
        ModelState.AddModelError(_localizer[LocalizationKeys.AccountRequiresEmailConfirmation]);
        return View(model);
      }

      var result = await _signInManager.PasswordSignInAsync(
          user,
          model.Password,
          model.RememberMe,
          _userService.IdentityOptions.Lockout.AllowedForNewUsers);

      if (result.Succeeded)
      {
        return RedirectToReturnUrl(model.ReturnUrl);
      }

      ProcessSignInResult(result);

      return View(model);
    }

    [HttpGet]
    [AllowAnonymous]
    public new async Task<IActionResult> SignOut()
    {
      await _signInManager.SignOutAsync();
      return Redirect("~/");
    }

    [HttpGet]
    public IActionResult AccessDenied()
    {
      // We have to manually set status code to 403
      Response.StatusCode = StatusCodes.Status403Forbidden;
      return View();
    }

    [HttpGet]
    public IActionResult LockScreen()
    {
      return View();
    }

    #region Utils

    [NonAction]
    private bool IsValidUserAccount(User user)
    {
      if (user is null || !user.IsActive)
      {
        ModelState.AddModelError(_localizer[LocalizationKeys.InvalidLoginData]);
        return false;
      }

      return true;
    }

    [NonAction]
    private void ProcessSignInResult(Microsoft.AspNetCore.Identity.SignInResult result)
    {
      ModelState.AddModelErrorIf(result.IsLockedOut, _localizer[LocalizationKeys.AccountLockedOut]);
      ModelState.AddModelErrorIf(result.IsNotAllowed, _localizer[LocalizationKeys.AccountNotAllowed]);
      ModelState.AddModelErrorIf(result.RequiresTwoFactor, _localizer[LocalizationKeys.AccountRequiresTwoFactor]);
      // Required so we don't end up with failed login without message
      ModelState.AddModelErrorIf(!result.IsLockedOut && !result.IsNotAllowed && !result.RequiresTwoFactor, _localizer[LocalizationKeys.InvalidLoginData]);
    }

    #endregion Utils
  }
}
