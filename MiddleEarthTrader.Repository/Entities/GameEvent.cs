using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiddleEarthTrader.Repository.Entities
{
    public class GameEvent : BaseEntity
    {
        [Required]
        [StringLength(200)]
        public string Name { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        public EventType Type { get; set; }

        public EventImpactLevel ImpactLevel { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public bool IsActive { get; set; } = true;

        // Navigation Properties
        public ICollection<MaterialPriceModifier> MaterialPriceModifiers { get; set; }
    }

    public enum EventType
    {
        Battle,
        Political,
        Natural,
        Magical
    }

    public enum EventImpactLevel
    {
        Low = 1,
        Medium = 2,
        High = 3,
        Critical = 4
    }
}
