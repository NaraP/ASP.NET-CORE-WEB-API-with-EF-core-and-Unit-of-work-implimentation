using DataAccessLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Dtos;
using ServiceLayer.IServices;

namespace UnitOfWorkRepositoryPatterns.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService; 
        public EmployeeController(IEmployeeService employeeService) 
        {
            _employeeService = employeeService;
        }

        [HttpGet(Name = "GetAllEmployees")]
        public async Task<IEnumerable<EmployeeDto>> GetAllEmployees()  
          => await _employeeService.GetAllEmployees();

        [HttpPost(Name = "AddEmployee")]
        public async Task AddEmployee([FromBody] EmployeeDto employeeDto) 
        {
            await _employeeService.AddEmployee(employeeDto);
        }

        [HttpPut(Name = "UpdateEmployee")]
        public async Task UpdateEmployee([FromBody] EmployeeDto employeeDto)
        {
            await _employeeService.UpdateEmployee(employeeDto);
        }

        [HttpDelete(Name = "DeleteEmployee")]
        public async Task DeleteEmployee([FromBody] int empId)  
        {
            await _employeeService.DeleteEmployee(empId);
        }
    }
}
