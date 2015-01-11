

using System.Data.Entity;

namespace Neemo.DataAccess
{
    public class NeemoDbContext : DbContext
    {
        public NeemoDbContext()
            : base ("NeemoConnection")
        {
            
        }

        static NeemoDbContext()
        {
            // Don't use any fancy intializers ( we don't do migrations )
            System.Data.Entity.Database.SetInitializer<NeemoDbContext>(null);
        }

    }
}
