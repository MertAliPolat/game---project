using Microsoft.EntityFrameworkCore;
using MiddleEarthTrader.Repository.ContextDb;
using MiddleEarthTrader.Repository.Entities;
using MiddleEarthTrader.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiddleEarthTrader.Repository.Repositories
{
    public class InventoryRepository : IInventoryRepository
    {
        private readonly AppDbContext _context;

        public InventoryRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<User?> GetUserByIdAsync(Guid userId) =>
            await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);

        public async Task<Material?> GetMaterialByIdAsync(Guid materialId) =>
            await _context.Materials.FirstOrDefaultAsync(m => m.Id == materialId);

        public async Task<Inventory?> GetInventoryAsync(Guid userId, Guid materialId) =>
            await _context.Inventories
                .Include(i => i.Material)
                .FirstOrDefaultAsync(i => i.UserId == userId && i.MaterialId == materialId);

        public async Task<IEnumerable<Inventory>> GetUserInventoriesAsync(Guid userId) =>
            await _context.Inventories
                .Include(i => i.Material)
                .Where(i => i.UserId == userId)
                .ToListAsync();

        public async Task SaveChangesAsync() =>
            await _context.SaveChangesAsync();
    }
}