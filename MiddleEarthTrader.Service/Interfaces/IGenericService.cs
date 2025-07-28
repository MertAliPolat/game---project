using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiddleEarthTrader.Service.Interfaces
{
    public interface IGenericService<TDto>
    {
        Task<IEnumerable<TDto>> GetAllAsync();
    }
}
