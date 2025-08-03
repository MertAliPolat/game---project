using Microsoft.EntityFrameworkCore;
using MiddleEarthTrader.Repository.ContextDb;
using MiddleEarthTrader.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiddleEarthTrader.Repository.Repositories
{
    public class GameEventRepository
    {
        private readonly AppDbContext _context;

        public GameEventRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<GameEvent>> GetAllAsync()
        {
            return await _context.GameEvents.ToListAsync();
        }
    }
}
