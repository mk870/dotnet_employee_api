using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using studentApi.DTOs.Employee;
using studentApi.Helpers.QueryParamObjects;
using studentApi.Models;

namespace studentApi.Services.Employees.Interfaces
{
    public interface IEmployeeService
    {
        Task<List<EmployeeResponseDTO>> GetAllEmployeesService(EmployeeQueryParams queryParams);
        Task<EmployeeResponseDTO> CreateEmployeeService(AddEmployeeDto addEmployeeDto);
        Task<EmployeeResponseDTO?> GetEmployeeByIdService(int id);
        Task<bool?> DeleteEmployeByIdService(int id);
        Task<EmployeeResponseDTO> UpdateEmployeeByIdService(UpdateEmployeeDTO updateEmployeeDTO, int id);
    }
}