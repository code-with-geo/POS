using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Classes
{
    public class Products
    {
        public int Id { get; set; }
        public string Barcode { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal SupplierPrice { get; set; }
        public decimal RetailPrice { get; set; }
        public decimal WholesalePrice { get; set; }
        public int ReorderLevel { get; set; }
        public string Remarks { get; set; }
        public int IsVat { get; set; }
        public int Status { get; set; }
        public int CategoryId { get; set; }
        public DateTime? DateCreated { get; set; }
    }
}
