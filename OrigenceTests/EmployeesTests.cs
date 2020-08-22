using NUnit.Framework;
using Origence.Logic;
using Origence.Models;
using Origence.Repos;
using System;
using System.Threading.Tasks;

namespace OrigenceTests
{
    public class Tests
    {
        protected EmployeesRepo EmployeesRepo { get; set; }
        protected EmployeesLogic EmployeesLogic { get; set; }
        [OneTimeSetUp]
        public async Task Setup()
        {
            EmployeesRepo = new EmployeesRepo();
            await EmployeesRepo.Add(new Employee(new EmployeeConstructorInput {
                Address = "123 Main St., Los Angeles, CA 90210", 
                DateOfBirth = new System.DateTime(), 
                Department = "Engineering", 
                Name = "Joe Smith", 
                Role = "Senior Developer" 
            }));
        }

        [Test]
        public async Task Employees_FindById()
        {
            var allEmployees = await EmployeesRepo.GetAll();
            var firstEmployeeId = allEmployees[0].ID;
            var firstEmployeeRecord = await EmployeesRepo.FindById(firstEmployeeId);
            Assert.IsNotNull(firstEmployeeRecord);
        }
    }
}