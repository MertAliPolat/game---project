using MiddleEarthTrader.Repository.Entities;

namespace MiddleEarthTrader.Repository.Interfaces
{
    public interface IInventoryRepository
    {
        Task<User?> GetUserByIdAsync(Guid userId);
        Task<Material?> GetMaterialByIdAsync(Guid materialId);
        Task<Inventory?> GetInventoryAsync(Guid userId, Guid materialId);
        Task<IEnumerable<Inventory>> GetUserInventoriesAsync(Guid userId);
        Task SaveChangesAsync();
    }
}