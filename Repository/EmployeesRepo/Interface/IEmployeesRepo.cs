using studentApi.Helpers.QueryParamObjects;
using studentApi.Models;

namespace studentApi.Repository.EmployeesRepo.Interface
{
    public interface IEmployeesRepo
    {
        Task<List<Employee>> GetAllEmployeesRepo(EmployeeQueryParams queryParams);
        Task<Employee> CreateEmployeeRepo(Employee employee);
        Task<Employee?> GetEmployeeByIdRepo(int id);
        Task<bool?> DeleteEmployeByIdRepo(int id);
        Task<Employee> UpdateEmployeeByIdRepo(Employee employee, int id);
    }
}