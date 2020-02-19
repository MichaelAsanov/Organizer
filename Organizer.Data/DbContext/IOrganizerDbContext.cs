using System.Data.Entity;
using Task = Organizer.Domain.Entities.Task;

namespace Organizer.Data.DbContext
{
    public interface IOrganizerDbContext
    {
        IDbSet<Task> Tasks { get; set; }
    }
}
