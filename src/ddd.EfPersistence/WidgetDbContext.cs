using System.Data.Entity;

namespace ddd.EfPersistence
{
    public class WidgetDbContext : DbContext
    {
        public WidgetDbContext(string connectionStringName)
            : base(connectionStringName)
        {
        }

        public WidgetDbContext()
            : this("DefaultConnection")
        {
            // todo: add this as a web config setting
            Database.SetInitializer(new DropCreateDatabaseAlways<WidgetDbContext>());
        }

    }
}