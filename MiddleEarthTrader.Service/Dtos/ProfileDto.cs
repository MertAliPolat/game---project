using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiddleEarthTrader.Service.Dtos
{
    public class ProfileDto
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public decimal Gold { get; set; }
        public string Role { get; set; }
        public List<InventoryDto> Inventories { get; set; }


    }
}
