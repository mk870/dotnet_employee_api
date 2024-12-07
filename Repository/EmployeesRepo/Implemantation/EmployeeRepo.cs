using studentApi.DB;
using studentApi.Models;
using Microsoft.EntityFrameworkCore;
using studentApi.Helpers.QueryParamObjects;
using studentApi.Repository.EmployeesRepo.Interface;

namespace studentApi.Repository.EmployeesRepo.Implemantation
{
    public class EmployeeRepo(ApplicationDBContext dBContext) : IEmployeesRepo
    {
        private ApplicationDBContext _dbContext = dBContext;

        public async Task<Employee> CreateEmployeeRepo(Employee employee)
        {
            await _dbContext.Set<Employee>().AddAsync(employee);
            await _dbContext.SaveChangesAsync();
            return employee;
        }

        public async Task<bool?> DeleteEmployeByIdRepo(int id)
        {
            var entity = await _dbContext.Set<Employee>().FindAsync(id);
            if (entity == null) return null;
            else
            {
                _dbContext.Set<Employee>().Attach(entity);
                _dbContext.Set<Employee>().Remove(entity);
                _dbContext.SaveChanges();
                return true;
            }
        }

        public async Task<List<Employee>> GetAllEmployeesRepo(EmployeeQueryParams queryParams)
        {
            var employees = _dbContext.Employees.AsQueryable();
            if(!string.IsNullOrWhiteSpace(queryParams.Department)){
                employees = employees.Where(e=>e.Department.Contains(queryParams.Department));
            }
            if(!string.IsNullOrWhiteSpace(queryParams.Title)){
                employees = employees.Where(e=>e.Title.Contains(queryParams.Title));
            }
            return await employees.ToListAsync();
        }

        public async Task<Employee?> GetEmployeeByIdRepo(int id)
        {
            var employee = await _dbContext.Employees.FirstOrDefaultAsync(x => x.Id == id);
            if (employee == null) return null;
            else return employee;
        }

        public async Task<Employee> UpdateEmployeeByIdRepo(Employee employee, int id)
        {
            var item = await _dbContext.Set<Employee>().FindAsync(id);
            _dbContext.Entry(item).CurrentValues.SetValues(employee);
            await _dbContext.SaveChangesAsync();
            return employee;
        }
    }
}