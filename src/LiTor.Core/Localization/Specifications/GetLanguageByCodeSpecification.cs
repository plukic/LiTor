using LiTor.Core.Localization.Domain;
using Ardalis.Specification;

namespace LiTor.Core.Localization.Specifications;
public class GetLanguageByCodeSpecification : Specification<Language>, ISingleResultSpecification
{
  public GetLanguageByCodeSpecification(string normalizedSearchCode)
  {
    Query
      .Where(x => !x.IsDeleted)
      .Where(x => x.CodeNormalized == normalizedSearchCode);
  }
}
