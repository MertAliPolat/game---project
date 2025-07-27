using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiddleEarthTrader.Repository.Entities
{
    public class Material : BaseEntity
    {
        [Required]
        [StringLength(200)]
        public string Name { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        [Required]
        public MaterialType Type { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        [Range(0.01, 100000)]
        public decimal BasePrice { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal CurrentPrice { get; set; }

        [Range(0, int.MaxValue)]
        public int TotalStock { get; set; }

        [Range(0, int.MaxValue)]
        public int AvailableStock { get; set; }

        public decimal RarityFactor { get; set; }

        [ForeignKey(nameof(CreatedByUser))]
        public Guid CreatedByUserId { get; set; }
        public User CreatedByUser { get; set; }


        // Navigation Properties
        public ICollection<Inventory> Inventories { get; set; }
        public ICollection<Trade> Trades { get; set; }
        public ICollection<MaterialPriceHistory> PriceHistories { get; set; }
    }

    public enum MaterialType
    {
        Weapon,
        Armor,
        Magical,
        Consumable,
        Crafting,
        Rare
    }

}

