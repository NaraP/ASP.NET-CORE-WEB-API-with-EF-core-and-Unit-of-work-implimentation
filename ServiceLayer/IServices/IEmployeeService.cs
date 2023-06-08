using DataAccessLayer.Models;
using ServiceLayer.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.IServices
{
    public interface IEmployeeService
    {
        public Task<IEnumerable<EmployeeDto>> GetAllEmployees();
        public Task<int> AddEmployee(EmployeeDto employeeDto);
        public Task<int> UpdateEmployee(EmployeeDto employeeDto);
        public Task<int> DeleteEmployee(int empid);
    }
}
