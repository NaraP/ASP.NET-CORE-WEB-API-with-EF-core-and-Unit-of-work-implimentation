using DataAccessLayer.Models;
using ServiceLayer.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Mapper
{
    public static class EmployeeMapper
    {
        public static List<EmployeeDto> EmployeeToEmployeeDto(IEnumerable<Employee> employees) 
        {
            List<EmployeeDto> EmployeeDtos = new List<EmployeeDto>(); 

           foreach (var emp in employees)  
            {
                var employee = new EmployeeDto 
                {
                    EmployeeId = emp.EmployeeId,
                    Name = emp.Name,
                    Citry = emp.Citry,
                    Department = emp.Department,
                    Gender = emp.Gender,
                };
                EmployeeDtos.Add(employee);
            }
            return EmployeeDtos;
        }
    }
}
