using System;
using System.Collections.Generic;

namespace DataAccessLayer.Models
{
    public partial class Employee
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string Citry { get; set; }
        public string Department { get; set; }
        public string Gender { get; set; }
    }
}
