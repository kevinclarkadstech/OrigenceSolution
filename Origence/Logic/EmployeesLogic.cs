using Origence.Models;
using Origence.Models.Exceptions;
using Origence.Models.View;
using Origence.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Origence.Logic
{
#nullable enable
    public interface IEmployeeLogic
    {
        public Task<Employee> AddEmployee(AddEmployeeVm vm);
        public Task<Employee> UpdateEmployee(Guid id, UpdateEmployeeVm vm);
        public Task RemoveEmployee(Guid id);
        public Task<IList<Employee>> GetAllEmployees();
        public Task<Employee?> FindEmployeeById(Guid id);
    }
    public class EmployeesLogic : IEmployeeLogic
    {
        protected IEmployeesRepo EmployeesRepo { get; set; }
        public EmployeesLogic(IEmployeesRepo employeesRepo)
        {
            EmployeesRepo = employeesRepo;
        }
        public async Task<Employee> AddEmployee(AddEmployeeVm vm)
        {
            var newEmployee = new Employee(new EmployeeConstructorInput
            {
                Address = vm.Address,
                DateOfBirth = vm.DateOfBirth,
                Department = vm.Department,
                Name = vm.Name,
                Role = vm.Role
            });
            newEmployee.Validate();
            await EmployeesRepo.Add(newEmployee);
            return newEmployee;
        }

        public async Task<Employee> UpdateEmployee(Guid id, UpdateEmployeeVm vm)
        {
            var existingEmployee = await EmployeesRepo.FindById(id);
            if (existingEmployee == null)
            {
                throw new EntityNotFoundException();
            }
            var updatedEmployee = new Employee(new EmployeeConstructorInput
            {
                ID = id,
                Address = vm.Address,
                DateOfBirth = vm.DateOfBirth,
                Department = vm.Department,
                Name = vm.Name,
                Role = vm.Role,
                IsActive = vm.IsActive
            });
            updatedEmployee.Validate();
            await EmployeesRepo.Update(id, updatedEmployee);
            return updatedEmployee;
        }

        public async Task RemoveEmployee(Guid id)
        {
            var existingEmployee = await EmployeesRepo.FindById(id);
            if (existingEmployee == null)
            {
                throw new EntityNotFoundException();
            }
            await EmployeesRepo.Remove(id);
        }

        public async Task<IList<Employee>> GetAllEmployees()
        {
            return await EmployeesRepo.GetAll();
        }

        public  async Task<Employee?> FindEmployeeById(Guid id)
        {
            return await EmployeesRepo.FindById(id);
        }
    }
}
