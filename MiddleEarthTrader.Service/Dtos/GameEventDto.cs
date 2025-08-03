using MiddleEarthTrader.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiddleEarthTrader.Service.Dtos
{
    public class GameEventDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }

        public DateTime? StartDate { get; set; }
        public string ImpactLevel { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
