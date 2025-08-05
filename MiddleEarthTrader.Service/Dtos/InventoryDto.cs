using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiddleEarthTrader.Service.Dtos
{
    public class InventoryDto
    {
        public Guid MaterialId { get; set; }
        public string MaterialName { get; set; }
        public int Quantity { get; set; }
        public decimal AveragePurchasePrice { get; set; }
    }
}
