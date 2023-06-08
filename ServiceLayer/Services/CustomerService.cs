using AutoMapper;
using DataAccessLayer.Models;
using RespositoryLayer.UnitOfWork;
using ServiceLayer.Dtos;
using ServiceLayer.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services
{
    public class CustomerService : ICustomerService
    {
        public IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper; 
        public CustomerService(IUnitOfWork unitOfWork,IMapper mapper) 
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Task<int> AddCustomer(CustomerDto employeeDto)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteEmployee(EmployeeDto employeeDto)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<CustomerDto>> GetAllCustomers()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CustomerDto>> GetCustomerById(int customerId)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateEmployee(EmployeeDto employeeDto)
        {
            throw new NotImplementedException();
        }
    }
}
