using Microsoft.EntityFrameworkCore;
using MiddleEarthTrader.Repository.Entities;

namespace MiddleEarthTrader.Repository.DbContext
{
    public class AppDbContext : DbContext

    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Character> characters { get; set; }

    }
}
