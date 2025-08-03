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
    public class MaterialRepository
    {
        private readonly AppDbContext _context;

        public MaterialRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Material>> GetAllMaterialsAsync()
        {
            return await _context.Materials
                .Include(m => m.Nation) 
                .ToListAsync();
        }

        public async Task ModifyPricesAsync(List<MaterialPriceModifier> modifiers)
        {
            foreach (var modifier in modifiers)
            {
                var existingModifier = await _context.MaterialPriceModifiers
                    .FirstOrDefaultAsync(x => x.MaterialId == modifier.MaterialId && x.EventId == modifier.EventId);
                var material = await _context.Materials
                    .FirstOrDefaultAsync(m => m.Id == modifier.MaterialId);

                if (material == null)
                    throw new Exception("Material bulunamadı");

                if (existingModifier != null)
                {
                    existingModifier.PriceModifierPercentage = modifier.PriceModifierPercentage;
                    _context.MaterialPriceModifiers.Update(existingModifier);
                }
                else
                {
                    await _context.MaterialPriceModifiers.AddAsync(modifier);
                }

   
                material.CurrentPrice = material.CurrentPrice * (1 + modifier.PriceModifierPercentage);

                _context.Materials.Update(material);
            }

            await _context.SaveChangesAsync();
        }


    }
}
