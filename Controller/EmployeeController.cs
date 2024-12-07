using studentApi.DB;
using studentApi.DTOs.Employee;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using studentApi.Helpers.QueryParamObjects;
using studentApi.Mappers;
using studentApi.Services.Employees.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace studentApi.Controller
{
    [ApiController]
    [Route("api/employees")]
    [Authorize]
    public class EmployeeController(
        IEmployeeService employeeService
    ) : ControllerBase
    {
        private IEmployeeService _employeeService = employeeService;

        [HttpGet]
        public async Task<ActionResult<EmployeeResponseDTO>> Employees([FromQuery] EmployeeQueryParams queryParams)
        {
            return Ok(await _employeeService.GetAllEmployeesService(queryParams));
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<EmployeeResponseDTO>> GetEmployee(int id)
        {
            var employee = await _employeeService.GetEmployeeByIdService(id);
            if (employee == null) return NotFound();
            return Ok(employee);
        }

        [HttpPost]
        public async Task<ActionResult<EmployeeResponseDTO>> PostEmployee(AddEmployeeDto addEmployeeDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var employee = await _employeeService.CreateEmployeeService(addEmployeeDto);
            return CreatedAtAction(nameof(GetEmployee), new { id = employee.Id }, employee);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<EmployeeResponseDTO>> UpdateEmployee(
            UpdateEmployeeDTO updateEmployeeDTO, int id
        )
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            return Ok(await _employeeService.UpdateEmployeeByIdService(updateEmployeeDTO, id));
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<bool>> DeleteEmployee(int id)
        {
            var isEmployeeDeleted = await _employeeService.DeleteEmployeByIdService(id);
            if (isEmployeeDeleted == null) return NotFound();
            return NoContent();
        }
    }
}