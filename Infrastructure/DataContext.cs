using Gestion_RH.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options):base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Bassin>().Property(x => x.BassinId).HasDefaultValueSql("NEWID()");
            modelBuilder.Entity<Observateur>().Property(x => x.ObservateurId).HasDefaultValueSql("NEWID()");
            modelBuilder.Entity<User>().Property(x => x.UserId).HasDefaultValueSql("NEWID()");
            modelBuilder.Entity<Station>().Property(x => x.StationId).HasDefaultValueSql("NEWID()");
            modelBuilder.Entity<RelativeHumidity>().Property(x => x.RelativeHumidityId).HasDefaultValueSql("NEWID()");

        }

        public DbSet<Bassin> Bassins { get; set; }
        public DbSet<Observateur> Observateurs { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Station> Stations { get; set; }
        public DbSet<RelativeHumidity> RelativeHumiditys { get; set; }


    }
}

