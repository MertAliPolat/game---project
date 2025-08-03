using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiddleEarthTrader.Service.Dtos;

namespace MiddleEarthTrader.Service.Interfaces
{
    public interface IMaterialService :  IGenericService<MaterialDto>
    {
        Task ModifyPricesAsync(List<MaterialPriceModifierDto> modifiers);

    }
}
