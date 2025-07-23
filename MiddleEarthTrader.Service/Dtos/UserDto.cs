using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiddleEarthTrader.Service.Dtos
{
    public class UserDto
    {
        public Guid Id { get; set; } 
        public string Username { get; set; }
        public string Email { get; set; }
        public decimal Gold { get; set; }
        public string NationName { get; set; }
    }
}
