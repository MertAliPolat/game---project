using MiddleEarthTrader.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiddleEarthTrader.Service.Dtos
{
    public class MaterialDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public MaterialType Type { get; set; }
        public decimal BasePrice { get; set; }
        public decimal CurrentPrice { get; set; }
        public int TotalStock { get; set; }
        public int AvailableStock { get; set; }
        public decimal RarityFactor { get; set; }

        public string NationName { get; set; }
        public decimal PriceChangePercentage { get; set; }

    }
}
