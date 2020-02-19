using System.Data.Entity;
using System.Reflection;
using Organizer.Domain.Entities;

namespace Organizer.Data.DbContext
{
    public class OrganizerDbContext : System.Data.Entity.DbContext, IOrganizerDbContext
    {
        public OrganizerDbContext() : this("Organizer") { }
                    

        public OrganizerDbContext(string name) : base(name) { }       
        
        public IDbSet<Task> Tasks { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.AddFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
