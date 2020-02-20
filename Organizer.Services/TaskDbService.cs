using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Organizer.Data.DbContext;
using Organizer.Domain.Interfaces;
using Task = Organizer.Domain.Entities.Task;

namespace Organizer.Services
{
    /// <summary>
    /// Реализация интерфейса для работы с задачами
    /// </summary>
    public class TaskDbService : ITaskDbService
    {
        /// <summary>
        /// Возвращает задачу по идентификатору
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task GetTaskById(int id)
        {
            using (var context = new OrganizerDbContext())
            {
                return context.Tasks.AsNoTracking().FirstOrDefault(x => x.Id == id);
            }
        }


        /// <summary>
        /// Возвращает список всех задач
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Task> GetTasks()
        {
            using (var context = new OrganizerDbContext())
            {
                return context.Tasks.AsNoTracking().ToList();
            }
        }

        /// <summary>
        /// Добавляет новую задачу
        /// </summary>
        /// <param name="task"></param>
        public void AddTask(Task task)
        {
            using (var context = new OrganizerDbContext())
            {
                context.Tasks.Add(task);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Удаляет задачу
        /// </summary>
        /// <param name="id"></param>
        public void DeleteTask(int id)
        {
            using (var context = new OrganizerDbContext())
            {
                var persistTask = GetTaskById(id);
                
                if (persistTask != null)
                {
                    context.Tasks.Attach(persistTask);
                    context.Tasks.Remove(persistTask);
                    context.SaveChanges();
                }
            }
        }

        /// <summary>
        /// Помечает задачу как выполненную
        /// </summary>
        /// <param name="task"></param>
        public void MarkTaskAsCompleted(Task task)
        {
            using (var context = new OrganizerDbContext())
            {
                var persistTask = GetTaskById(task.Id);

                if (persistTask != null)
                {
                    context.Tasks.Attach(persistTask);
                    persistTask.Completed = true;
                    context.SaveChanges();
                }
            }
        }
    }
}
