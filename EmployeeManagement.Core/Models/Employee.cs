using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Core.Models
{
    public class Employee
    {
        public int Age { get; set; }
        public int YearsOfExperience { get; set; }
        public bool HasPenalty { get; set; }
        public bool IsActive { get; set; }
    }
}
