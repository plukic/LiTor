using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiTor.Core.Localization;
/// <summary>
/// Abstraction for accessing current language id
/// </summary>
public interface ICurrentLanguageAccessor
{
  Task<LanguageDto> GetCurrentLanguageAsync();
}
