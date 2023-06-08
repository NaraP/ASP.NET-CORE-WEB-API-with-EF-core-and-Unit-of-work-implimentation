using ServiceLayer.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.IServices
{
    public interface ICustomerService
    {
        public Task<IEnumerable<CustomerDto>> GetAllCustomers();
        public Task<int> AddCustomer(CustomerDto employeeDto);
        public Task<int> UpdateEmployee(EmployeeDto employeeDto);
        public Task<int> DeleteEmployee(EmployeeDto employeeDto);
        public Task<IEnumerable<CustomerDto>> GetCustomerById(int customerId); 
    }
}
