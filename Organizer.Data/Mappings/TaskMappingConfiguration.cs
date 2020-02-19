using System.Data.Entity.ModelConfiguration;
using Task = Organizer.Domain.Entities.Task;

namespace Organizer.Data.Mappings
{
    public class TaskMappingConfiguration : EntityTypeConfiguration<Task>
    {
        public TaskMappingConfiguration()
        {
            HasKey(x => x.Id);

            Property(x => x.Description).IsRequired().HasMaxLength(256);
            Property(x => x.Completed).IsRequired();
        }
    }
}
