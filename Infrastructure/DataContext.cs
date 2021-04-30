using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options):base(options)
        {

        }
        
        public DbSet<Bassin> Bassins { get; set; }
        public DbSet<Observateur> Observateurs { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Station> Stations { get; set; }
        public DbSet<RelativeHumidity> RelativeHumiditys { get; set; }


    }
}

