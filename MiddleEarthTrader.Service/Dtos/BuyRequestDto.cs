﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiddleEarthTrader.Service.Dtos
{
    public class BuyRequestDto
    {
        public Guid UserId { get; set; }
        public Guid MaterialId { get; set; }
        public int Quantity { get; set; }
    }
}
