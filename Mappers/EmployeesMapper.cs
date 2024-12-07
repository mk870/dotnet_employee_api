using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using studentApi.DTOs.Employee;
using studentApi.Models;

namespace studentApi.Mappers
{
    public static class EmployeesMapper
    {
        public static EmployeeResponseDTO ToEmployeeResponseDTO(this Employee employee)
        {
            return new EmployeeResponseDTO
            {
                Id = employee.Id,
                GivenName = employee.GivenName,
                FamilyName = employee.FamilyName,
                Department = employee.Department,
                Title = employee.Title,
                Salary = employee.Salary
            };
        }

        public static Employee NewEmployeeToEmployeeModel(this AddEmployeeDto newEmployee)
        {
            return new Employee
            {
                GivenName = newEmployee.GivenName,
                FamilyName = newEmployee.FamilyName,
                Department = newEmployee.Department,
                Title = newEmployee.Title,
                Salary = newEmployee.Salary
            };
        }

        public static Employee UpdateEmployeeToEmployeeModel(this UpdateEmployeeDTO updatedEmployee)
        {
            return new Employee
            {
                Id = updatedEmployee.Id,
                GivenName = updatedEmployee.GivenName,
                FamilyName = updatedEmployee.FamilyName,
                Department = updatedEmployee.Department,
                Title = updatedEmployee.Title,
                Salary = updatedEmployee.Salary
            };
        }
    }
}