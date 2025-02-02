using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Classes
{
    public class OrderResponse
    {
        public string InvoiceNo { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal TotalDiscount { get; set; }
        public decimal TotalVatSale { get; set; }
        public decimal TotalVatAmount { get; set; }
        public decimal TotalVatExempt { get; set; }
    }
}
