using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiddleEarthTrader.Repository.Entities;


namespace MiddleEarthTrader.Repository.Interfaces
{
    public interface IInventoryRepository
    {
        Task<IEnumerable<Inventory>> BuyMaterialAsync(Guid userId, Guid materialId, int quantity);
        Task<IEnumerable<Inventory>> SellMaterialAsync(Guid userId, Guid materialId, int quantity);
    }
}
