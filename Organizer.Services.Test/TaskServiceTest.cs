using System;
using System.Data.Entity;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Organizer.Domain.Entities;
using Organizer.TestData;

namespace Organizer.Services.Test
{
    /// <summary>
    /// Класс для тестирования сервиса для работы с задачами
    /// </summary>
    [TestClass]
    public class TaskServiceTest
    {
        /// <summary>
        /// Устанваливает инициализатор БД
        /// </summary>
        static TaskServiceTest()
        {
            Database.SetInitializer(new OrganizerDbDataInitializer());
        }

        /// <summary>
        /// Тестирует получение задач из БД
        /// </summary>
        [TestMethod]
        public void GetListOfTasksTest()
        {
            var taskService = new TaskDbService();
            var tasks = taskService.GetTasks();
            Assert.IsNotNull(tasks);
        }

        /// <summary>
        /// Тестирует получение задач по идентификатору
        /// </summary>
        [TestMethod]
        public void GetTaskByIdTest()
        {
            var taskService = new TaskDbService();
            var task = taskService.GetTaskById(1);
            Assert.IsNotNull(task);
        }

        /// <summary>
        /// Дестирует добавление задачи в БД
        /// </summary>
        [TestMethod]
        public void AddTaskTest()
        {
            var taskService = new TaskDbService();

            var tasks = taskService.GetTasks();
            var countOfTasks = tasks.Count();


            var task = new Task()
            {
                Description = "Реализовать класс рациональных чисел"
            };

            taskService.AddTask(task);
            var tasksAfterInsert = taskService.GetTasks();
            var countOfTasksAfterInsert = tasksAfterInsert.Count();

            Assert.AreEqual(countOfTasks + 1, countOfTasksAfterInsert);
        }

        /// <summary>
        /// Тестирует удаление задачи из БД
        /// </summary>
        [TestMethod]
        public void MarkTaskAsCompletedTest()
        {
            var taskService = new TaskDbService();
            var task = taskService.GetTaskById(1);
            Assert.IsFalse(task.Completed);

            taskService.MarkTaskAsCompleted(task);

            var markedCompletedTask = taskService.GetTaskById(1);
            Assert.IsTrue(markedCompletedTask.Completed);
        }

        /// <summary>
        /// Тестирует удаление задачи из БД
        /// </summary>
        [TestMethod]
        public void DeleteTaskTest()
        {
            var taskService = new TaskDbService();
            var tasks = taskService.GetTasks().ToArray();

            var countOfTasks = tasks.Length;
            var indexOfTaskToDelete = new Random().Next(countOfTasks);
            var taskIdToDelete = tasks[indexOfTaskToDelete].Id;

            taskService.DeleteTask(taskIdToDelete);

            var deletedTask = taskService.GetTaskById(taskIdToDelete);
            Assert.IsNull(deletedTask);

            var tasksAfterDelete = taskService.GetTasks().ToArray();
            var countOfTasksAfterDelete = tasksAfterDelete.Length;

            Assert.AreEqual(countOfTasks-1, countOfTasksAfterDelete);
        }
    }
}
