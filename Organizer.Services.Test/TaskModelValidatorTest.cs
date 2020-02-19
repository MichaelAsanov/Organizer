using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Organizer.UI.Web.Models.Validators;
using Organizer.UI.Web.Models.ViewModels;

namespace Organizer.Services.Test
{
    /// <summary>
    /// Тестирует валидацию модели задач
    /// </summary>
    [TestClass]
    public class TaskModelValidatorTest
    {
        /// <summary>
        /// Тестирует валидацию модели задачи с пустым описанием
        /// </summary>
        [TestMethod]
        public void TaskModelWithEmptyDescriptionTest()
        {
            var model = new TaskViewModel() {};
            var validator = new TaskModelValidator();
            var validationResult = validator.Validate(model);

            //ожидаем, что модель невалидна
            Assert.IsFalse(validationResult.IsValid);
        }

        /// <summary>
        /// Тестирует валидацию модели задачи с непустым описанием
        /// </summary>
        [TestMethod]
        public void TaskModelWithNotEmptyDescriptionTest()
        {
            var model = new TaskViewModel() {Description = "Реализовать класс комплексных чисел"};
            var validator = new TaskModelValidator();
            var validationResult = validator.Validate(model);

            //ожидаем, что модель валидна
            Assert.IsTrue(validationResult.IsValid);
        }
    }
}
