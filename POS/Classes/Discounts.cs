using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Classes
{
    public class Discounts
    {
        public int DiscountId { get; set; }
        public string Name { get; set; }
        public int Percentage { get; set; }
        public int Status { get; set; }
        public DateTime? DateCreated { get; set; }
    }
}
