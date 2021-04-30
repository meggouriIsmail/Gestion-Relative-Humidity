using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options):base(options)
        {

        }
        
        public DbSet<Bassin> Bassin { get; set; }
        public DbSet<Observateur> Observateur { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Station> Station { get; set; }
        public DbSet<RelativeHumidity> RelativeHumidity { get; set; }


    }
}

