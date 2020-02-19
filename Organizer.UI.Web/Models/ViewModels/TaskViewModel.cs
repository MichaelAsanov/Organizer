using FluentValidation.Attributes;
using Organizer.UI.Web.Models.Validators;

namespace Organizer.UI.Web.Models.ViewModels
{
    /// <summary>
    /// Вью-модель задачи
    /// </summary>
    [Validator(typeof(TaskModelValidator))]
    public class TaskViewModel
    {
        public int Id { get; set; }

        public string Description { get; set; }
    }
}