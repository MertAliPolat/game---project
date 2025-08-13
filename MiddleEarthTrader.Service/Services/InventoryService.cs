using MiddleEarthTrader.Repository.Interfaces;
using MiddleEarthTrader.Service.Dtos;
using MiddleEarthTrader.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiddleEarthTrader.Service.Services
{
    public class InventoryService : IInventoryService
    {

        private readonly IInventoryRepository _inventoryRepository;

        public InventoryService(IInventoryRepository inventoryRepository)
        {
            _inventoryRepository = inventoryRepository;
        }

        public async Task<IEnumerable<InventoryDto>> BuyMaterialAsync(Guid userId, Guid materialId, int quantity)
        {
            // Repository’den güncel inventory listesini al
            var inventories = await _inventoryRepository.BuyMaterialAsync(userId, materialId, quantity);

            // Entity → DTO map işlemi
            var inventoryDtos = inventories.Select(i => new InventoryDto
            {
                MaterialId = i.MaterialId,
                MaterialName = i.Material?.Name ?? "Unknown", 
                Quantity = i.Quantity,
                AveragePurchasePrice = i.AveragePurchasePrice
            });

            return inventoryDtos;
        }

        public async Task<IEnumerable<InventoryDto>> SellMaterialAsync(Guid userId, Guid materialId, int quantity)
        {
            // Repository’den güncel inventory listesini al
            var inventories = await _inventoryRepository.SellMaterialAsync(userId, materialId, quantity);

            // Entity → DTO map işlemi
            var inventoryDtos = inventories.Select(i => new InventoryDto
            {
                MaterialId = i.MaterialId,
                MaterialName = i.Material?.Name ?? "Unknown",
                Quantity = i.Quantity,
                AveragePurchasePrice = i.AveragePurchasePrice
            });

            return inventoryDtos;
        }
    }
}
