using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace studentApi.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string GivenName { get; set; } = string.Empty;
        public string FamilyName { get; set; } = string.Empty;
        public string Department { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public double Salary { get; set; } = 0.00;
    }
}