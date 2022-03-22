using Microsoft.EntityFrameworkCore;

namespace Pandemic.Models
{
    public class PandemicContext : DbContext
    {
        public DbSet<Hospital> Hospitals { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<ReportType> ReportTypes { get; set; }
        public DbSet<Patient> Patients { get; set; }

        public PandemicContext() { }

        public PandemicContext(DbContextOptions<PandemicContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            optionsBuilder.EnableSensitiveDataLogging(true)
                .UseNpgsql("Server=127.0.0.1;Port=54321;Database=pandemic;User Id=postgres;Password=@Passw0rd;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Hospital>()
                .HasQueryFilter(x => x.IsDeleted == 0);
            modelBuilder.Entity<Doctor>()
                .HasQueryFilter(x => x.IsDeleted == 0);
            modelBuilder.Entity<Report>()
                .HasQueryFilter(x => x.IsDeleted == 0);
            modelBuilder.Entity<ReportType>()
                .HasQueryFilter(x => x.IsDeleted == 0);
            modelBuilder.Entity<Patient>()
                .HasQueryFilter(x => x.IsDeleted == 0);
        }
    }
}
