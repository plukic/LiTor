using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiTor.SharedKernel;
/// <summary>
/// Implements GUID generation using built-in methods
/// </summary>
public class DefaultGuidGenerator : IGuidGenerator
{
  /// <summary>
  /// Static instance when DI is not possible
  /// </summary>
  public static DefaultGuidGenerator Instance => new();

  public DefaultGuidGenerator()
  {

  }

  public Guid Generate() => Guid.NewGuid();
}
