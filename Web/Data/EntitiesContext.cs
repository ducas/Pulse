using System.Data.Entity;

namespace Web.Data
{
    public class EntitiesContext : DbContext
    {
        public DbSet<BusinessEntity> BusinessEntities { get; set; }
    }
}