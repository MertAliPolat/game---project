﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiddleEarthTrader.Repository.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; } 
        public ICollection<Material> Materials { get; set; }
    }
}
