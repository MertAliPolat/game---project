using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiddleEarthTrader.Repository.Entities;

namespace MiddleEarthTrader.Repository.Interfaces
{
    public interface IMaterialRepository
    {
        Task<IEnumerable<Material>> GetAllMaterialsAsync();
        Task ModifyPricesAsync(List<MaterialPriceModifier> modifiers);
    }
}
