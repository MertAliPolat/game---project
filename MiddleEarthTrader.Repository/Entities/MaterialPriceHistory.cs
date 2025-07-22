using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiddleEarthTrader.Repository.Entities
{
    public class MaterialPriceHistory : BaseEntity
    {
        [ForeignKey(nameof(Material))]
        public Guid MaterialId { get; set; }
        public Material Material { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        public DateTime PriceDate { get; set; } = DateTime.UtcNow;

    }
}
