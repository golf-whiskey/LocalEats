using LocalEats.Core;
using Microsoft.EntityFrameworkCore;

namespace LocalEats.Data
{
    public class LocalEatsDbContext : DbContext
    {
        public LocalEatsDbContext(DbContextOptions<LocalEatsDbContext> options)
            : base(options)
        {
        }

        public DbSet<Restaurant> Restaurants { get; set; }
    }
}