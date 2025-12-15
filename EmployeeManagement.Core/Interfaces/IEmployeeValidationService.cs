using EmployeeManagement.Core.Enums;
using EmployeeManagement.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Core.Interfaces
{
    public interface IEmployeeValidationService
    {
        ValidationResultType Validate(Employee employee);

        bool IsAgeValid(int age);
        bool IsEmployeeActive(bool isActive);
        bool HasMinimumExperience(int yearsOfExperience);
        bool IsAgeWithinWorkingRange(int age);
        bool IsEmployeeEligible(Employee employee);
        bool HasValidBasicData(Employee employee);
        ValidationResultType ValidateAge(int age);
        ValidationResultType ValidateActivityStatus(bool isActive);
        ValidationResultType ValidateExperience(int yearsOfExperience);
    }
}
