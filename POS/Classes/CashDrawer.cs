using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Classes
{
    public class CashDrawer
    {
        public int DrawerId { get; set; }
        public int UserId { get; set; }
        public int LocationId { get; set; }
        public decimal InitialCash { get; set; }
        public decimal TotalSales { get; set; }
        public decimal Withdrawals { get; set; }
        public decimal Expense { get; set; }
        public decimal DrawerCash { get; set; }
        public DateTime TimeStart { get; set; }
        public DateTime? TimeEnd { get; set; }
        public int Status { get; set; }
    }
}
