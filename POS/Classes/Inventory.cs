using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Classes
{
    public class Inventory
    {
        public int InventoryId { get; set; }
        public string Specification { get; set; }
        public int Units { get; set; }
        public int ProductId { get; set; }
        public int LocationId { get; set; }
        public int Status { get; set; }
        public DateTime? DateCreated { get; set; }
    }
}
