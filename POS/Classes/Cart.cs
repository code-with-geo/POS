using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Classes
{
    public class Cart
    {
        public int Id { get; set; }
        public string Barcode { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public decimal VatAmount { get; set; }  // Add VatAmount property
        public decimal SubTotal { get; set; }
        public decimal AppliedDiscount { get; set; }
        public decimal TotalDiscount { get; set; }
        public int DiscountId { get; set; }
        public int IsVat { get; set; }
        public bool HasDiscountApplied { get; set; }
        public decimal DiscountPercentage { get; set; }
    }
}
