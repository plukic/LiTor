using System.ComponentModel.DataAnnotations;
using LiTor.Core.Localization;

namespace LiTor.Web.Models.Account;

public class AccountSignInViewModel
{
  [Display(Name = LocalizationKeys.Username, Prompt =LocalizationKeys.EmailSlashUsername)]
  public string Username { get; set; }

  [Display(Name = LocalizationKeys.Password, Prompt = LocalizationKeys.PasswordHint)]
  [DataType(DataType.Password)]
  public string Password { get; set; }

  [Display(Name = LocalizationKeys.RememberMe)]
  public bool RememberMe { get; set; }

  public string ReturnUrl { get; set; }
}
