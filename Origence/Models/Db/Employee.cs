using Origence.Models.Exceptions;
using System;
using System.Collections.Generic;

namespace Origence.Models
{
    public class EmployeeConstructorInput
    {
        public Guid? ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Role { get; set; }
        public string Department { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool? IsActive { get; set; }
    }

    public class Employee
    {
        public Guid ID { get; private set; }
        public string Name { get; private set; }
        public string Address { get; private set; }
        public string Role { get; private set; }
        public string Department { get; private set; }
        public DateTime DateOfBirth { get; private set; }
        public bool IsActive { get; private set; }

        public Employee(EmployeeConstructorInput input)
        {
            if (input.ID == null)
            {
                ID = Guid.NewGuid();
            } else
            {
                ID = input.ID.Value;
            }
            Name = input.Name;
            Address = input.Address;
            Role = input.Role;
            Department = input.Department;
            DateOfBirth = input.DateOfBirth;
            if (input.IsActive == null)
            {
                IsActive = true;
            } else
            {
                IsActive = input.IsActive.Value;
            }
        }

        public void Validate()
        {
            IList<string> validationErrors = new List<string>();
            if (Name == null)
            {
                validationErrors.Add("Name is required.");
            }
            else
            {
                if (Name.Length > 25)
                {
                    validationErrors.Add("Name is limited to 25 characters.");
                }
            }

            if (Address == null)
            {
                validationErrors.Add("Address is required.");
            }
            else
            {
                if (Address.Length > 100)
                {
                    validationErrors.Add("Address is limited to 100 characters.");
                }
            }

            if (Role == null)
            {
                validationErrors.Add("Role is required.");
            }

            if (Department == null)
            {
                validationErrors.Add("Department is required.");
            }
            if (DateOfBirth == null)
            {
                validationErrors.Add("Date of birth is required.");
            }

            if (validationErrors.Count > 0)
            {
                throw new ValidationException(validationErrors);
            }
        }
    }
}
