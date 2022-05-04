using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiTor.Core.Localization.Commands;
using LiTor.Core.Localization.Domain;
using LiTor.Core.Localization.Specifications;
using LiTor.SharedKernel.Caching;
using LiTor.SharedKernel.Interfaces;
using LiTor.SharedKernel.TextNormalizers;
using Ardalis.Result;
using MediatR;
using Microsoft.Extensions.Caching.Distributed;

namespace LiTor.Core.Localization;
/// <summary>
/// TODO: Cache languages
/// </summary>
public class LanguageService : ILanguageService, INotificationHandler<LanguageDataChangedEvent>
{
  private readonly string AllLanguagesDataCacheKey = "LanguageService_AllLanguagesDataCacheKey";

  private readonly IRepository<Language> _languageRepository;
  private readonly ITextNormalizer _textNormalizer;
  private readonly ICacheAccessor _cache;

  public LanguageService(IRepository<Language> languageRepository, ITextNormalizer textNormalizer, ICacheAccessor cache)
  {
    _languageRepository = languageRepository;
    _textNormalizer = textNormalizer;
    _cache = cache;
  }
  private LanguageDto MapDtoFromEntity(Language language)
  {
    return new LanguageDto
    {
      Name = language.Name,
      Code = language.Code,
      CodeNormalized = language.CodeNormalized,
      IconImageName = language.IconImageName,
      Id = language.Id,
      IsDefault = language.IsDefault,
    };
  }


  public async Task<IReadOnlyCollection<LanguageDto>> GetAllAsync()
  {
    var cachedLanguagesResult = await _cache.GetAsync<List<LanguageDto>>(AllLanguagesDataCacheKey);
    if (!cachedLanguagesResult.IsSuccess)
    {
      var availableLanguagesEntity = await _languageRepository.ListAsync(new GetAvailableLanguagesSpecification());
      var availableLanguagesDto = availableLanguagesEntity.Select(MapDtoFromEntity).ToList();

      await _cache.SetAsync(AllLanguagesDataCacheKey, availableLanguagesDto);
      return availableLanguagesDto;
    }
    return cachedLanguagesResult.Value;
  }

  public async Task<Result<LanguageDto>> GetByCodeAsync(string code)
  {
    var allLanguages = await GetAllAsync();
    var languageResult = allLanguages.Where(x => x.CodeNormalized == _textNormalizer.Normalize(code)).FirstOrDefault();
    if (languageResult == null)
    {
      return Result<LanguageDto>.NotFound();
    }
    return Result<LanguageDto>.Success(languageResult);
  }

  public async Task<Result<LanguageDto>> GetByIdAsync(int id)
  {
    var allLanguages = await GetAllAsync();

    var languageResult = allLanguages.Where(x => x.Id == id).FirstOrDefault();
    if (languageResult == null)
    {
      return Result<LanguageDto>.NotFound();
    }
    return Result<LanguageDto>.Success(languageResult);
  }

  public async Task<Result<LanguageDto>> GetDefaultAsync()
  {
    var allLanguages = await GetAllAsync();
    var defaultLang = allLanguages.Where(x => x.IsDefault).FirstOrDefault();
    if (defaultLang == null)
    {
      return Result<LanguageDto>.NotFound();
    }
    return Result<LanguageDto>.Success(defaultLang);
  }

  public Task Handle(LanguageDataChangedEvent notification, CancellationToken cancellationToken)
  {
    return _cache.RefreshAsync(AllLanguagesDataCacheKey);
  }
}
