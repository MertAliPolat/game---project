using Microsoft.EntityFrameworkCore;
using MiddleEarthTrader.Repository.Entities;


namespace MiddleEarthTrader.Repository.ContextDb
{
    public class AppDbContext : DbContext

    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Material>()
                .HasOne<Nation>(m => m.Nation)
                .WithMany(n => n.AvailableMaterials)
                .HasForeignKey(m => m.NationId);

            modelBuilder.Entity<Inventory>()
                .HasOne(i => i.User)
                .WithMany()
                .HasForeignKey(i => i.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Trade>()
                .HasOne(t => t.User)
                .WithMany()
                .HasForeignKey(t => t.UserId)
                .OnDelete(DeleteBehavior.Restrict); 

            modelBuilder.Entity<Category>()
               .Property(x => x.Id)
               .HasDefaultValueSql("NEWID()");

            modelBuilder.Entity<Inventory>()
        .HasOne(i => i.User)
        .WithMany(u => u.Inventories)
        .HasForeignKey(i => i.UserId);

            base.OnModelCreating(modelBuilder);
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
