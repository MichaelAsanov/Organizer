using FluentValidation.Results;

namespace Organizer.UI.Web.Models.Validators
{
    public interface IValidationService
    {
        ValidationResult Validate<T>(T model) where T : class;
    }
}