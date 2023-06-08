using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RespositoryLayer.Repository.EmployeeRepository
{
    public interface IEmployeeRepository : IGenericRepository<Employee>
    {
    }
}
