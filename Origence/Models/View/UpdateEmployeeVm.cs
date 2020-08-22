using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Origence.Models.View
{
    public class UpdateEmployeeVm
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Role { get; set; }
        public string Department { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool IsActive { get; set; }
    }
}
