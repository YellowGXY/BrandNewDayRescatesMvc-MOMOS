using System.Data.Entity;

namespace BrandNewDayRescatesMvc.Models
{
    public class BrandNewDayDbContext : DbContext
    {
        public BrandNewDayDbContext() : base("name=BrandNewDayDbContext") { }

        public DbSet<Heroe> Heroes { get; set; }
        public DbSet<Rescate> Rescates { get; set; }
    }
}