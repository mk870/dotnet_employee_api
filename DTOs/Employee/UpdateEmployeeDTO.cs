using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace studentApi.DTOs.Employee
{
    public class UpdateEmployeeDTO:EmployeeDTO
    {
        [Required]
        public int Id { get; set; }
    }
}