using LiTor.Core.Localization.Domain;
using Ardalis.Specification;

namespace LiTor.Core.Localization.Specifications;
public class GetLanguageByIdSpecification : Specification<Language>, ISingleResultSpecification
{
  public GetLanguageByIdSpecification(int id)
  {
    Query
      .Where(x => !x.IsDeleted)
      .Where(x => x.Id == id);
  }
}
