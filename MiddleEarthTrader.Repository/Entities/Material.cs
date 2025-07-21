using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiddleEarthTrader.Repository.Entities
{
    internal class Material
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Features { get; set; }
        public decimal BaseValue { get; set; } // Taban fiyat
        public int CategoryId { get; set; }
    }
}
