using Microsoft.EntityFrameworkCore;
using MiddleEarthTrader.Repository.ContextDb;
using MiddleEarthTrader.Repository.Entities;
using MiddleEarthTrader.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        public async Task<IEnumerable<Inventory>> BuyMaterialAsync(Guid userId, Guid materialId, int quantity)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);
            if (user == null)
                throw new Exception("User not found");

            var material = await _context.Materials.FirstOrDefaultAsync(m => m.Id == materialId);
            if (material == null)
                throw new Exception("Material not found");

            if (material.AvailableStock < quantity)
                throw new Exception("Not enough stock available");

            var totalCost = material.CurrentPrice * quantity;
            if (user.Gold < totalCost)
                throw new Exception("Not enough gold to buy this material");

            user.Gold -= totalCost;
            _context.Users.Update(user);

            material.AvailableStock -= quantity;
            _context.Materials.Update(material);

            var inventory = await _context.Inventories
                .FirstOrDefaultAsync(i => i.UserId == userId && i.MaterialId == materialId);

            if (inventory != null)
            {
                inventory.Quantity += quantity;
                _context.Inventories.Update(inventory);
            }
            else
            {
                var newInventory = new Inventory
                {
                    UserId = userId,
                    MaterialId = materialId,
                    Quantity = quantity,
                    AveragePurchasePrice = 0
                };

                await _context.Inventories.AddAsync(newInventory);
            }

            await _context.SaveChangesAsync();

            return await _context.Inventories
                .Include(i => i.Material)
                .Where(i => i.UserId == userId)
                .ToListAsync();
        }


        public async Task<IEnumerable<Inventory>> SellMaterialAsync(Guid userId, Guid materialId, int quantity)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);
            if (user == null)
                throw new Exception("User not found");

            var material = await _context.Materials.FirstOrDefaultAsync(m => m.Id == materialId);
            if (material == null)
                throw new Exception("Material not found");

            var inventory = await _context.Inventories
                .FirstOrDefaultAsync(i => i.UserId == userId && i.MaterialId == materialId);

            if (inventory == null || inventory.Quantity < quantity)
                throw new Exception("Not enough material in inventory to sell");

            var totalGain = material.CurrentPrice * quantity;
            user.Gold += totalGain;
            _context.Users.Update(user);

            material.AvailableStock += quantity;
            _context.Materials.Update(material);

            inventory.Quantity -= quantity;
            if (inventory.Quantity <= 0)
            {
                _context.Inventories.Remove(inventory);
            }
            else
            {
                _context.Inventories.Update(inventory);
            }

            await _context.SaveChangesAsync();

            return await _context.Inventories
                .Include(i => i.Material)
                .Where(i => i.UserId == userId)
                .ToListAsync();
        }

    }

}