using Microsoft.EntityFrameworkCore;

namespace EPasport.Models
{
    public class EPasportContext : DbContext
    {
        public DbSet<TechObject> TechObjects { get; set; }
        public DbSet<MaintenanceWorks> MaintenanceWorks { get; set; }

        public EPasportContext(DbContextOptions<EPasportContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
