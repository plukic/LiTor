using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiTor.Core.Features.Licensing;
public class CreateLicenseResponse
{
  public string PrivateKey { get; set; }
  public string PublicKey { get; set; }
  public string PassPhrase { get; set; }

  public string LicenseContent { get; set; }
}
