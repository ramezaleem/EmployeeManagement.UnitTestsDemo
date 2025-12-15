using EmployeeManagement.Core.Enums;
using EmployeeManagement.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Core.Services
{
    public class EmployeeValidationService
    {
        public ValidationResultType Validate(Employee employee)
        {
            if (!HasValidBasicData(employee))
                return ValidationResultType.InvalidAge;

            var ageResult = ValidateAge(employee.Age);
            if (ageResult != ValidationResultType.Valid)
                return ageResult;

            var activityResult = ValidateActivityStatus(employee.IsActive);
            if (activityResult != ValidationResultType.Valid)
                return activityResult;

            var experienceResult = ValidateExperience(employee.YearsOfExperience);
            if (experienceResult != ValidationResultType.Valid)
                return experienceResult;

            return ValidationResultType.Valid;
        }

        public bool IsAgeValid(int age)
        {
            return age >= 18 && age <= 60;
        }

        public bool IsEmployeeActive(bool isActive)
        {
            return isActive;
        }

        public bool HasMinimumExperience(int yearsOfExperience)
        {
            return yearsOfExperience >= 1;
        }

        public bool IsAgeWithinWorkingRange(int age)
        {
            return age >= 18 && age <= 65;
        }

        public bool IsEmployeeEligible(Employee employee)
        {
            return IsAgeValid(employee.Age)
                   && IsEmployeeActive(employee.IsActive)
                   && HasMinimumExperience(employee.YearsOfExperience);
        }

        public bool HasValidBasicData(Employee employee)
        {
            if (employee == null)
                return false;

            if (employee.Age < 0)
                return false;

            if (employee.YearsOfExperience < 0)
                return false;

            return true;
        }

        public ValidationResultType ValidateAge(int age)
        {
            if (!IsAgeValid(age))
                return ValidationResultType.InvalidAge;

            return ValidationResultType.Valid;
        }

        public ValidationResultType ValidateActivityStatus(bool isActive)
        {
            if (!IsEmployeeActive(isActive))
                return ValidationResultType.InactiveEmployee;

            return ValidationResultType.Valid;
        }

        public ValidationResultType ValidateExperience(int yearsOfExperience)
        {
            if (!HasMinimumExperience(yearsOfExperience))
                return ValidationResultType.InsufficientExperience;

            return ValidationResultType.Valid;
        }
    }
}
