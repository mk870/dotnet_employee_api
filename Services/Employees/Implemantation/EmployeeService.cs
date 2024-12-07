using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using studentApi.DTOs.Employee;
using studentApi.Helpers.QueryParamObjects;
using studentApi.Mappers;
using studentApi.Models;
using studentApi.Repository.EmployeesRepo.Interface;
using studentApi.Services.Employees.Interfaces;

namespace studentApi.Services.Employees.Implemantation
{
    public class EmployeeService(IEmployeesRepo employeesRepo) : IEmployeeService
    {
        private IEmployeesRepo _employeesRepo = employeesRepo;
        public async Task<EmployeeResponseDTO> CreateEmployeeService(AddEmployeeDto addEmployeeDto)
        {
            var newEmployee = await _employeesRepo.CreateEmployeeRepo(addEmployeeDto.NewEmployeeToEmployeeModel());
            return newEmployee.ToEmployeeResponseDTO();
        }

        public async Task<bool?> DeleteEmployeByIdService(int id)
        {
            var isEmployeeDeleted = await _employeesRepo.DeleteEmployeByIdRepo(id);
            if (isEmployeeDeleted == null) return null;
            return isEmployeeDeleted;
        }

        public async Task<List<EmployeeResponseDTO>> GetAllEmployeesService(EmployeeQueryParams queryParams)
        {
            var employees = await _employeesRepo.GetAllEmployeesRepo(queryParams);
            var convertedList = employees.Select(e => new EmployeeResponseDTO
            {
                Id = e.Id,
                GivenName = e.GivenName,
                FamilyName = e.FamilyName,
                Salary = e.Salary,
                Title = e.Title,
                Department = e.Department
            }).ToList();

            return convertedList;
        }

        public async Task<EmployeeResponseDTO?> GetEmployeeByIdService(int id)
        {
            var employee = await _employeesRepo.GetEmployeeByIdRepo(id);
            if (employee == null) return null;
            return employee.ToEmployeeResponseDTO();
        }

        public async Task<EmployeeResponseDTO> UpdateEmployeeByIdService(
            UpdateEmployeeDTO updateEmployeeDTO, int id
        )
        {
            var updatedEmployee = await _employeesRepo.UpdateEmployeeByIdRepo(
                updateEmployeeDTO.UpdateEmployeeToEmployeeModel(), id
            );
            return updatedEmployee.ToEmployeeResponseDTO();
        }
    }
}