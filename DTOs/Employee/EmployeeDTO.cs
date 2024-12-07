using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace studentApi.DTOs.Employee
{
    public class EmployeeDTO
    {
        [Required]
        [MinLength(3, ErrorMessage ="Given name should be 3 characters or more")]
        public required string GivenName { get; set; }
        [Required]
        [MinLength(3, ErrorMessage ="Family name should be 3 characters or more")]
        public required string FamilyName { get; set; }
        [Required]
        [MinLength(3, ErrorMessage ="Department should be 3 characters or more")]
        public required string Department { get; set; }
        [Required]
        [MinLength(3, ErrorMessage ="Title should be 3 characters or more")]
        public required string Title { get; set; }
        [Required]
        [Range(0,100000000)]
        public double Salary { get; set; }
    }
}