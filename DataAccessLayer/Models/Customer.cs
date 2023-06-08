using System;
using System.Collections.Generic;

namespace DataAccessLayer.Models 
{
    public partial class Customer
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Gender { get; set; }
    }
}
