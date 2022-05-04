using LiTor.Core.Localization;
using Microsoft.AspNetCore.Mvc;
namespace LiTor.Web.Components;

  public class LanguageMenu : ViewComponent
  {
      private readonly ILanguageService _languageService;
      private readonly ICurrentLanguageAccessor _currentLanguageAccessor;
      public LanguageMenu(ILanguageService languageService,
          ICurrentLanguageAccessor currentLanguageAccessor)
      {
          _languageService = languageService;
          _currentLanguageAccessor = currentLanguageAccessor;
      }

      public async Task<IViewComponentResult> InvokeAsync()
      {
          var languages = await _languageService.GetAllAsync();

          if (!languages.Any())
          {
              return Content(string.Empty);
          }
          var currentCulture = await _currentLanguageAccessor.GetCurrentLanguageAsync();
          var model = new LanguageMenuViewModel
          {
              CurrentCulture = currentCulture.Code,
              CurrentLanguage= currentCulture,
              Languages = languages
          };
          return View(model);
      }
  }
