using DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.Logging;
using Moq;
using RespositoryLayer.Repository.EmployeeRepository;
using ServiceLayer.Dtos;
using ServiceLayer.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWorkRepositoryPatterns.Controllers;
using Xunit;

namespace TestProject
{
    public class EmployeeControllerTest
    {
        private readonly Mock<IEmployeeService> _mockRepo;
        private readonly EmployeeController _controller;
        public EmployeeControllerTest() 
        {
            _mockRepo = new Mock<IEmployeeService>();
            _controller = new EmployeeController(_mockRepo.Object);
        }

        [Fact]
        public void Create_ModelStateValid_CreateEmployeeCalledOnce()
        {
            Employee? emp = new Employee();
            _mockRepo.Setup(r => r.AddEmployee(It.IsAny<EmployeeDto>()));

            var employee = new EmployeeDto
            {
                Name = "Test Employee",
                Citry = "BKR",
                Department = "IT",
                Gender="M"
            };

            _controller?.AddEmployee(employee);
            _mockRepo.Verify(x => x.AddEmployee(It.IsAny<EmployeeDto>()), Times.Once);

            Assert.Equal("Test Employee", employee.Name);
        }

        [Fact]
        public void GetAll_Employee_Success()
        {
            var results = _mockRepo.Setup(r => r.GetAllEmployees()); 
            var result = _controller.GetAllEmployees().Result;

            //Assert
            Assert.Equal(4, result.Count());
        }

        [Fact]
        public void Delete_Employee_Success()
        {
            int valid_empid = 3;
            int invalid_empid = 3;
        }
    }
}
