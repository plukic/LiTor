using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiTor.SharedKernel.TextNormalizers;
/// <summary>
/// Abstractions for text normalization. Used mostly when preparing values for filtering.
/// </summary>
public interface ITextNormalizer
{
  string Normalize(string value);
}
