using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiTor.SharedKernel.TextNormalizers;
public class UppercaseTextNormalizer : ITextNormalizer
{
  public string Normalize(string value) => value?.ToUpperInvariant();

}
