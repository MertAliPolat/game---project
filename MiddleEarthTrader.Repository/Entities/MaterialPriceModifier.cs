using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiddleEarthTrader.Repository.Entities
{
    public class MaterialPriceModifier
    {
        [ForeignKey(nameof(GameEvent))]
        public Guid EventId { get; set; }
        public GameEvent GameEvent { get; set; }

        [ForeignKey(nameof(Material))]
        public Guid MaterialId { get; set; }
        public Material Material { get; set; }

        [Range(-1, 1)]
        public decimal PriceModifierPercentage { get; set; }
    }
}
