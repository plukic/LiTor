using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiTor.Core.Localization.Domain;
using Ardalis.Specification;

namespace LiTor.Core.Localization.Specifications;
public class GetAvailableLanguagesSpecification : Specification<Language>
{
  public GetAvailableLanguagesSpecification()
  {
    Query.Where(x => !x.IsDeleted).OrderBy(x => x.Ordering);
  }
}
