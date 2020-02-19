using FluentValidation;
using Organizer.UI.Web.Models.ViewModels;

namespace Organizer.UI.Web.Models.Validators
{
    /// <summary>
    /// Валидатор модели задач
    /// </summary>
    public class TaskModelValidator : BaseValidator<TaskViewModel>
    {
        public TaskModelValidator()
        {
            RuleFor(organisation => organisation.Description)
                .NotEmpty()
                .WithMessage("Обязательное поле");
        }
    }
}