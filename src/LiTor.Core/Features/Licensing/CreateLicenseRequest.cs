using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace LiTor.Core.Features.Licensing;
public class CreateLicenseRequest : IRequest<CreateLicenseResponse>
{
  public string PassPhrase { get; set; }
}
