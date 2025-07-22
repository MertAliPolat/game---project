using Microsoft.EntityFrameworkCore;
using MiddleEarthTrader.Repository.Entities;


namespace MiddleEarthTrader.Repository.ContextDb
{
    public class AppDbContext : DbContext

    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Nation> Nations { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<Trade> Trades { get; set; }
        public DbSet<GameEvent> GameEvents { get; set; }
        public DbSet<MaterialPriceHistory> MaterialPriceHistories { get; set; }
        public DbSet<MaterialPriceModifier> MaterialPriceModifiers { get; set; }
        public DbSet<Category> Categories { get; set; }


    }
}
