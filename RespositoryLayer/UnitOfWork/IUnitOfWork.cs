using RespositoryLayer.Repository.CustomerRepos;
using RespositoryLayer.Repository.EmployeeRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RespositoryLayer.UnitOfWork
{
    public interface IUnitOfWork
    {
        IEmployeeRepository employeeRepository { get; }
        ICustomerRepository customerRepository { get; }
        Task<int> Commit();
        void Rollback();
        Task<int> CommitAsync();
        Task RollbackAsync();
    }
}
