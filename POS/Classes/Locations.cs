﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Classes
{
    public class Locations
    {
        public int LocationId { get; set; }
        public string Name { get; set; }
        public int Status { get; set; }
        public DateTime? DateCreated { get; set; }
    }
}
