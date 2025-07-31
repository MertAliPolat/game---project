using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MiddleEarthTrader.Repository.Entities
{
    public class Nation : BaseEntity
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public NationType Type { get; set; }

        [Range(0.1, 2.0)]
        public decimal TradeFactor { get; set; } = 1.0m;

        public bool IsAllowedTrading { get; set; } = true;

        // Navigation Properties
        

        public ICollection<Material> AvailableMaterials { get; set; }
    }

    public enum NationType
    {
        Gondor,
        Rohan,
        Mordor,
        Elves,
        Dwarves,
        Wizards,
        Hobbits
    }
}

