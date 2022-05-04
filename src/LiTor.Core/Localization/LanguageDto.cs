using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiTor.SharedKernel;

namespace LiTor.Core.Localization;
public class LanguageDto : BaseDto<int>
{
  public string Name { get; set; }
  public string Code { get; set; }
  public string CodeNormalized { get; set; }
  public string IconImageName { get; set; }
  public bool IsDefault { get; set; }
}
