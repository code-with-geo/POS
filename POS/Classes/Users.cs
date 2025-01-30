using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Classes
{
    public class Users
    {
        public int Id { get; set; }

        public int LocationId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public int IsRole { get; set; }
        public int Status { get; set; }
        public string Token { get; set; }
        public DateTime? DateCreated { get; set; }
    }
}
