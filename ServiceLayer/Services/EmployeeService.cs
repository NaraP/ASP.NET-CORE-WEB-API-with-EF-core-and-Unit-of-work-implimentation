using AutoMapper;
using DataAccessLayer.Models;
using RespositoryLayer.UnitOfWork;
using ServiceLayer.Dtos;
using ServiceLayer.IServices;
using ServiceLayer.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services
{
    public class EmployeeService : IEmployeeService
    {
        public IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EmployeeService(IUnitOfWork unitOfWork,IMapper mapper) 
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<EmployeeDto>> GetAllEmployees()
        {
            var employeListDto = default(IEnumerable<EmployeeDto>);

            var employeeLists = await _unitOfWork.employeeRepository.GetAllAsync();

            employeListDto = _mapper.Map<List<EmployeeDto>>(employeeLists);   

            return employeListDto;
        }

       public async Task<int> AddEmployee(EmployeeDto employeeDto)
        {
            var employee = _mapper.Map<Employee>(employeeDto);

            await _unitOfWork.employeeRepository.AddAsync(employee);

           return await _unitOfWork.CommitAsync();
        }

        public async Task<int> UpdateEmployee(EmployeeDto employeeDto)
        {
            var empExists = _unitOfWork.employeeRepository.GetById(employeeDto.EmployeeId);

            var employee = _mapper.Map<EmployeeDto, Employee>(employeeDto, empExists);

            _unitOfWork.employeeRepository.Update(employee);

            return await _unitOfWork.CommitAsync();
        }

        public async Task<int> DeleteEmployee(int empid)
        {
            var employee = _unitOfWork.employeeRepository.GetById(empid); 

            _unitOfWork.employeeRepository.Remove(employee);

            return await _unitOfWork.CommitAsync();
        }
    }
}
