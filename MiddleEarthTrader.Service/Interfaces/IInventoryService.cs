using MiddleEarthTrader.Service.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiddleEarthTrader.Service.Interfaces
{
    public interface IInventoryService
    {
        
            Task<IEnumerable<InventoryDto>> BuyMaterialAsync(Guid userId, Guid materialId, int quantity);
            Task<IEnumerable<InventoryDto>> SellMaterialAsync(Guid userId, Guid materialId, int quantity);

    }
}
