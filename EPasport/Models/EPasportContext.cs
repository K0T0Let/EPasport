using Microsoft.EntityFrameworkCore;

namespace EPasport.Models
{
    public class EPasportContext : DbContext
    {
        //Установка таблици TechObjects
        public DbSet<TechObject> TechObjects { get; set; }
        //Установка таблици MaintenanceWorks
        public DbSet<MaintenanceWorks> MaintenanceWorks { get; set; }

        //Создание БД
        public EPasportContext(DbContextOptions<EPasportContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
