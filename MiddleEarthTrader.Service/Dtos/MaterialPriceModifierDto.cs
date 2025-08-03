using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiddleEarthTrader.Service.Dtos
{
    public class MaterialPriceModifierDto
    {
        public Guid EventId { get; set; }
        public Guid MaterialId { get; set; }
        public decimal PriceModifierPercentage { get; set; }
    }
}
