using FluentValidation;
using FluentValidation.Results;

namespace Organizer.UI.Web.Models.Validators
{
    public class FluentValidationService : IValidationService
    {
        private readonly IValidatorFactory _validatorFactory;

        public FluentValidationService(IValidatorFactory validatorFactory)
        {
            _validatorFactory = validatorFactory;
        }

        public virtual ValidationResult Validate<T>(T model) where T : class
        {
            var validator = _validatorFactory.GetValidator(model.GetType());
            var result = validator.Validate(model);
            return result;
        }
    }
}