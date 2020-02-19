using System.Data.Entity;
using Organizer.Data.DbContext;
using Organizer.Domain.Entities;

namespace Organizer.TestData
{
    /// <summary>
    /// Инициализатор БД тестовыми данными.
    /// БД пересоздается пр каждом запуске приложения.
    /// </summary>
    public class OrganizerDbDataInitializer : DropCreateDatabaseAlways<OrganizerDbContext>
    {
        protected override void Seed(OrganizerDbContext context)
        {
            context.Tasks.Add(new Task()
            {
                Description = "Сделать карту сайта."
            });

            context.Tasks.Add(new Task()
            {
                Description = "Реализовать класс комплексных чисел", Completed = true
            });
            context.Tasks.Add(new Task()
            {
                Description = "Реализовать класс рациональных чисел."
            });
            context.Tasks.Add(new Task()
            {
                Description = "На базе типов double и класса векторов реализовать класс кватернионов. Написать тесты. " +
                              "Проверить утверждение, что два кватерниона перестановочны тогда " +
                              "и только тогда, когда их мнимые (векторные) части линейно зависимы."
            });
            context.SaveChanges();
        }
    }
}
