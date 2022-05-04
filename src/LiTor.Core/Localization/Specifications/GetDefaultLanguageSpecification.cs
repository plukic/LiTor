using LiTor.Core.Localization.Domain;
using Ardalis.Specification;

namespace LiTor.Core.Localization.Specifications;
public class GetDefaultLanguageSpecification : Specification<Language>, ISingleResultSpecification
{
  public GetDefaultLanguageSpecification()
  {
    Query
      .Where(x => !x.IsDeleted)
      .Where(x => x.IsDefault);
  }
}
