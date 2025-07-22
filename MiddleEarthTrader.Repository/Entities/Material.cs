using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiddleEarthTrader.Repository.Entities
{
    public class Material
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Features { get; set; }
        public string Source { get; set; }
        public decimal BaseValue { get; set; } 
        public int CategoryId { get; set; }
        public int RarityLevel { get; set; }
    }
}
