using Ardalis.Result;

namespace LiTor.Core.Localization;
public interface ILanguageService
{
  Task<IReadOnlyCollection<LanguageDto>> GetAllAsync();

  Task<Result<LanguageDto>> GetByIdAsync(int id);

  Task<Result<LanguageDto>> GetByCodeAsync(string code);

  Task<Result<LanguageDto>> GetDefaultAsync();
}
