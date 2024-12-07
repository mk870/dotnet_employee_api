using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace studentApi.DTOs.Employee
{
    public class EmployeeResponseDTO
    {
        public int Id { get; set; }
        
        public required string GivenName { get; set; }

        public required string FamilyName { get; set; }

        public required string Department { get; set; }

        public required string Title { get; set; }

        public double Salary { get; set; }
    }
}