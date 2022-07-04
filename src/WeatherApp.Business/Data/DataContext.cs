using Microsoft.EntityFrameworkCore;
using WeatherApp.Business.Models;

namespace WeatherApp.Business.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            ChangeTracker.AutoDetectChangesEnabled = false;
        }

        public DbSet<Temperature> Temperatures { get; set; }
        public DbSet<Humidity> Humidity { get; set; }
        public DbSet<Rainfall> Rainfall { get; set; }
        public DbSet<Weather> Weather { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Temperature>()
                .HasKey(t => t.TimeStamp);

            modelBuilder.Entity<Temperature>()
                .HasIndex(t => t.TimeStamp)
                .IsUnique();

            modelBuilder.Entity<Humidity>()
                .HasKey(hu => hu.TimeStamp);

            modelBuilder.Entity<Humidity>()
                .HasIndex(hu => hu.TimeStamp)
                .IsUnique();

            modelBuilder.Entity<Rainfall>()
                .HasKey(rain => rain.TimeStamp);

            modelBuilder.Entity<Rainfall>()
                .HasIndex(rain => rain.TimeStamp)
                .IsUnique();

            modelBuilder.Entity<Weather>(w =>
            {
                w.HasNoKey();
                w.ToView("vw_weather");
                w.Property(p => p.TimeStamp).HasColumnName("timestamp");
                w.Property(p => p.Temperature).HasColumnName("temperature");
                w.Property(p => p.Humidity).HasColumnName("humidity");
                w.Property(p => p.Rainfall).HasColumnName("rainfall");
            });

        }
    }
}
