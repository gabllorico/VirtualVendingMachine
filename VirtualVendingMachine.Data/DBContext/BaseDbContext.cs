using System.Data.Entity;
using System.Linq;
using VirtualVendingMachine.Domain;

namespace VirtualVendingMachine.Data.DBContext
{
    public class BaseDbContext : DbContext
    {
        protected BaseDbContext(string connectionstring)
            : base(connectionstring)
        {
        }

        //For Concurrency
        public override int SaveChanges()
        {
            var modifiedEntities = ChangeTracker.Entries()
                .Where(x => x.State == EntityState.Modified)
                .Select(x => x.Entity).ToList();

            foreach (var entity in modifiedEntities.Cast<BaseEntity>())
                entity.Version = entity.Version + 1;

            return base.SaveChanges();

        }
    }

}
