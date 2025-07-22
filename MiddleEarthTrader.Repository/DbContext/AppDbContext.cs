using Microsoft.EntityFrameworkCore;
using MiddleEarthTrader.Repository.Entities;

namespace MiddleEarthTrader.Repository.ContextDb
{
    public class AppDbContext : DbContext

    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Material> Materials { get; set; }
        public DbSet<Category> Categories { get; set; }


    }
}
