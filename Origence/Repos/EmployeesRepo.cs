using Origence.Models;
using Origence.Models.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Origence.Repos
{
#nullable enable
    public interface IEmployeesRepo
    {
        public Task Add(Employee employee);
        public Task Update(Guid id, Employee employee);
        public Task Remove(Guid id);
        public Task<IList<Employee>> GetAll();
        public Task<Employee?> FindById(Guid id);
    }
    public class EmployeesRepo : IEmployeesRepo
    {
        protected List<Employee> Employees = new List<Employee>();
        public async Task Add(Employee employee)
        {
            Employees.Add(employee);
        }

        public async Task<Employee?> FindById(Guid id)
        {
            return Employees.Find(e => e.ID == id);
        }

        public async Task<IList<Employee>> GetAll()
        {
            return Employees.AsReadOnly();
        }

        public async Task Remove(Guid id)
        {
            var index = Employees.FindIndex(e => e.ID == id);
            Employees.RemoveAt(index);
        }

        public async Task Update(Guid id, Employee employee)
        {
            var index = Employees.FindIndex(e => e.ID == id);
            if (index < 0)
            {
                throw new EntityNotFoundException();
            }
            Employees[index] = employee;
        }
    }
}
