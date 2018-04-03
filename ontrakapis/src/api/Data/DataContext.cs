using Microsoft.EntityFrameworkCore;
using api.Models;
using System.Threading.Tasks;

namespace api.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options) { }

        public DbSet<Nuance> Nuances { get; set; }
        public DbSet<Waypoint> Waypoints { get; set; }
        public DbSet<Document> Documents { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Nuance>().ToTable("Nuances");
            modelBuilder.Entity<Waypoint>().ToTable("Waypoints");
            modelBuilder.Entity<Document>().ToTable("Documents");
        }

        public async Task<int> WipeDatabase()
        {
            Database.ExecuteSqlCommand(@"
                SET FOREIGN_KEY_CHECKS = 0;
                TRUNCATE TABLE Nuances;
                TRUNCATE TABLE Waypoints;
                TRUNCATE TABLE Documents;
                SET FOREIGN_KEY_CHECKS = 1;
            ");
            return await Task.FromResult(0);
        }
    }
}
