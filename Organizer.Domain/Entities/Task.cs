using Common.Entities;

namespace Organizer.Domain.Entities
{
    /// <summary>
    /// Задача
    /// </summary>
    public class Task : BaseEntity<int>
    {
        /// <summary>
        /// Описание задачи
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Статус (выполнена/не выполнена)
        /// </summary>
        public bool Completed { get; set; }
    }
}
