using MiddleEarthTrader.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiddleEarthTrader.Repository.Interfaces
{
    public interface IGameEventRepository
    {
        Task<IEnumerable<GameEvent>> GetAllAsync();
    }
}
