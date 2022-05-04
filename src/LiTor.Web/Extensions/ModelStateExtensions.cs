using Ardalis.GuardClauses;
using Ardalis.Result;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace LiTor.Web.Extensions;

public static class ModelStateExtensions
{
  #region Methods

  public static void AddModelErrors(this ModelStateDictionary modelState, IDictionary<string, string> errors)
  {
    Guard.Against.Null(modelState, nameof(modelState));
    Guard.Against.Null(errors, nameof(errors));

    foreach (var error in errors)
    {
      modelState.AddModelError(error.Key, error.Value);
    }
  }

  public static void AddResultErrors<T>(this ModelStateDictionary modelState, Result<T> result)
  {
    Guard.Against.Null(modelState, nameof(modelState));
    Guard.Against.Null(result, nameof(result));

    if (result.ValidationErrors != null)
    {
      foreach (var error in result.ValidationErrors)
        modelState.AddModelError(error.ErrorMessage);
    }
    else
    {
      foreach (var error in result.Errors)
        modelState.AddModelError(error);
    }

  }

  public static void AddResultErrors(this ModelStateDictionary modelState, IEnumerable<string> errors)
  {
    Guard.Against.Null(modelState, nameof(modelState));
    Guard.Against.Null(errors, nameof(errors));

    foreach (var error in errors)
    {
      modelState.AddModelError(string.Empty, error);
    }
  }

  /// <summary>
  /// Returns all model state errors as collection
  /// </summary>
  public static IEnumerable<string> GetFlattenedErrors(this ModelStateDictionary modelState)
  {
    Guard.Against.Null(modelState, nameof(modelState));

    return modelState.Values.SelectMany(s => s.Errors).Select(s => s.ErrorMessage);
  }

  public static void AddModelErrors(this ModelStateDictionary modelState, IEnumerable<string> errors)
  {
    Guard.Against.Null(modelState, nameof(modelState));
    Guard.Against.Null(errors, nameof(errors));

    foreach (var error in errors)
    {
      modelState.AddModelError(string.Empty, error);
    }
  }

  /// <summary>
  /// Adds <see cref="Cleaners.Models.Result.Errors"/> to model state dictionary
  /// </summary>
  /// <param name="modelState"></param>
  /// <param name="errors"></param>
  //public static void AddResultErrors(this ModelStateDictionary modelState, IEnumerable<ResultError> errors)
  //{
  //    Guard.Against.Null(modelState, nameof(modelState));
  //    Guard.Against.Null(errors, nameof(errors));

  //    foreach (var error in errors)
  //    {
  //        modelState.AddModelError(error.Key, error.Message);
  //    }
  //}

  /// <summary>
  /// Shorthand method for ModelState.AddModelError(string.Empty, error);
  /// </summary>
  /// <param name="modelState"></param>
  /// <param name="error"></param>
  public static void AddModelError(this ModelStateDictionary modelState, string error)
  {
    Guard.Against.Null(modelState, nameof(modelState));

    modelState.AddModelError(string.Empty, error);
  }

  /// <summary>
  /// Used for cleaner code when multiple if cases are present
  /// </summary>
  /// <param name="modelState"></param>
  /// <param name="condition"></param>
  /// <param name="error"></param>
  public static void AddModelErrorIf(this ModelStateDictionary modelState, bool condition, string error)
  {
    Guard.Against.Null(modelState, nameof(modelState));

    if (condition)
    {
      modelState.AddModelError(string.Empty, error);
    }
  }

  #endregion Methods
}
