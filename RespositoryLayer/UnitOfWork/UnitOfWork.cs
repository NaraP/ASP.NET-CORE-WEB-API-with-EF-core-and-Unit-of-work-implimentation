using DataAccessLayer.Models;
using Microsoft.Extensions.Logging;
using RespositoryLayer.Repository.CustomerRepos;
using RespositoryLayer.Repository.EmployeeRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RespositoryLayer.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EmployeeDBContext _dbContext;
        private IEmployeeRepository? _employeeRepository;
        private ICustomerRepository? _customerRepository;

        public readonly ILogger? _logger;

        public UnitOfWork(EmployeeDBContext dbContext) 
        {
            _dbContext = dbContext;
        }

        public IEmployeeRepository employeeRepository 
        {
            get { return _employeeRepository = _employeeRepository ?? new EmployeeRepository(_dbContext); }
        }

        public ICustomerRepository customerRepository
        {
            get { return _customerRepository = _customerRepository ?? new CustomerRepository(_dbContext); }
        }

        public async Task<int> Commit()
        {
           return await _dbContext.SaveChangesAsync();
        }

        public async Task<int> CommitAsync()
        {
          return  await _dbContext.SaveChangesAsync();
        }

        public void Rollback()
            => _dbContext.Dispose();

        public async Task RollbackAsync()
            => await _dbContext.DisposeAsync();
    }
}
