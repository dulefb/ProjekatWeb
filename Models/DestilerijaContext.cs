using Microsoft.EntityFrameworkCore;

namespace Models
{
    public class DestilerijaContext : DbContext
    {
        public DbSet<Burad> Burad {get; set;}
        public DbSet<Radnik> Radnik {get; set;}
        public DbSet<Proizvodnja> Proizvodnja {get; set;}

        public DbSet<Proizvod> Proizvod {get; set;}

        public DestilerijaContext(DbContextOptions options) : base(options)
        {
            
        }
    }
}