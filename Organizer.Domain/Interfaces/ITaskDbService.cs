using System.Collections.Generic;
using Organizer.Domain.Entities;


namespace Organizer.Domain.Interfaces
{
    /// <summary>
    /// Интерфейс сервиса для работы с задачами
    /// </summary>
    public interface ITaskDbService
    {
        /// <summary>
        /// Возвращает задачу по идентификатору
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task GetTaskById(int id);

        /// <summary>
        /// Возвращает список всех задач
        /// </summary>
        /// <returns></returns>
        IEnumerable<Task> GetTasks();

        /// <summary>
        /// Добавляет новую задачу
        /// </summary>
        /// <param name="task"></param>
        void AddTask(Task task);

        /// <summary>
        /// Удаляет задачу
        /// </summary>
        /// <param name="id"></param>
        void DeleteTask(int id);

        /// <summary>
        /// Помечает задачу как выполненную
        /// </summary>
        /// <param name="task"></param>
        void MarkTaskAsCompleted(Task task);
    }
}
