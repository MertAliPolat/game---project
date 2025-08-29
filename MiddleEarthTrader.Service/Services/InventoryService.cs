using MiddleEarthTrader.Repository.ContextDb;
using MiddleEarthTrader.Repository.Entities;
using MiddleEarthTrader.Repository.Interfaces;
using MiddleEarthTrader.Service.Dtos;
using MiddleEarthTrader.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiddleEarthTrader.Service.Services
{
    public class InventoryService : IInventoryService
    {
        private readonly AppDbContext _context; // transaction için DbContext direkt alıyoruz
        private readonly IInventoryRepository _inventoryRepository;

        public InventoryService(AppDbContext context, IInventoryRepository inventoryRepository)
        {
            _context = context;
            _inventoryRepository = inventoryRepository;
        }

        public async Task<IEnumerable<InventoryDto>> BuyMaterialAsync(Guid userId, Guid materialId, int quantity)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();

            var user = await _inventoryRepository.GetUserByIdAsync(userId)
                       ?? throw new Exception("User not found");

            var material = await _inventoryRepository.GetMaterialByIdAsync(materialId)
                          ?? throw new Exception("Material not found");

            if (material.AvailableStock < quantity)
                throw new Exception("Not enough stock available");

            var totalCost = material.CurrentPrice * quantity;
            if (user.Gold < totalCost)
                throw new Exception("Not enough gold");

            // İş mantığı
            user.Gold -= totalCost;
            material.AvailableStock -= quantity;

            var inventory = await _inventoryRepository.GetInventoryAsync(userId, materialId);
            if (inventory != null)
            {
                inventory.Quantity += quantity;
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
                _context.Inventories.Add(newInventory);
            }

            await _inventoryRepository.SaveChangesAsync();
            await transaction.CommitAsync();

            var inventories = await _inventoryRepository.GetUserInventoriesAsync(userId);

            return inventories.Select(i => new InventoryDto
            {
                MaterialId = i.MaterialId,
                MaterialName = i.Material?.Name ?? "Unknown",
                Quantity = i.Quantity,
                AveragePurchasePrice = i.AveragePurchasePrice
            });
        }

        public async Task<IEnumerable<InventoryDto>> SellMaterialAsync(Guid userId, Guid materialId, int quantity)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();

            var user = await _inventoryRepository.GetUserByIdAsync(userId)
                       ?? throw new Exception("User not found");

            var material = await _inventoryRepository.GetMaterialByIdAsync(materialId)
                          ?? throw new Exception("Material not found");

            var inventory = await _inventoryRepository.GetInventoryAsync(userId, materialId)
                          ?? throw new Exception("Inventory not found");

            if (inventory.Quantity < quantity)
                throw new Exception("Not enough material in inventory");

            var totalGain = material.CurrentPrice * quantity;

            // İş mantığı
            user.Gold += totalGain;
            material.AvailableStock += quantity;

            inventory.Quantity -= quantity;
            if (inventory.Quantity <= 0)
            {
                _context.Inventories.Remove(inventory);
            }

            await _inventoryRepository.SaveChangesAsync();
            await transaction.CommitAsync();

            var inventories = await _inventoryRepository.GetUserInventoriesAsync(userId);

            return inventories.Select(i => new InventoryDto
            {
                MaterialId = i.MaterialId,
                MaterialName = i.Material?.Name ?? "Unknown",
                Quantity = i.Quantity,
                AveragePurchasePrice = i.AveragePurchasePrice
            });
        }
    }
}
