using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Classes
{
    public class Customers
    {
        public int CustomerId { get; set; }
        public int AccountId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ContactNo { get; set; }
        public string Email { get; set; }
        public int TransactionCount { get; set; }
        public string CardNumber { get; set; }
        public int Points { get; set; }
        public int Status { get; set; }
        public DateTime? DateCreated { get; set; }
    }
}
