using EmployeeManagement.Core.Enums;
using EmployeeManagement.Core.Models;
using EmployeeManagement.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Tests.ValidationServiceTests
{
    [TestFixture]
    public class EmployeeValidationServiceTests
    {
        private EmployeeValidationService employeeValidation;
        private Employee employee;

        [SetUp]
        public void SetUp()
        {
            employeeValidation = new EmployeeValidationService();
            employee = new Employee();
        }

        [Test]
        public void HasValidBasicData_ShouldReturnFalse_WhenEmployeeIsNull()
        {
            Employee employee = null;

            var result = employeeValidation.HasValidBasicData(employee);

            Assert.That(result, Is.False);
        }

        [Test]
        public void HasValidBasicData_ShouldReturnFalse_WhenAgeIsNegative()
        {
            var employee = new Employee
            {
                Age = -1,
                YearsOfExperience = 2,
                IsActive = true
            };

            var result = employeeValidation.HasValidBasicData(employee);

            Assert.That(result, Is.False);
        }

        [Test]
        public void HasValidBasicData_ShouldReturnFalse_WhenExperienceIsNegative()
        {
            var employee = new Employee
            {
                Age = 25,
                YearsOfExperience = -5,
                IsActive = true
            };

            var result = employeeValidation.HasValidBasicData(employee);

            Assert.That(result, Is.False);
        }

        [Test]
        public void HasValidBasicData_ShouldReturnTrue_WhenEmployeeDataIsValid()
        {
            var employee = new Employee
            {
                Age = 30,
                YearsOfExperience = 3,
                IsActive = true
            };

            var result = employeeValidation.HasValidBasicData(employee);

            Assert.That(result, Is.True);
        }


        [TestCase(17,false)]
        [TestCase(18,true)]
        [TestCase(60,true)]
        [TestCase(61,false)]
        public void IsAgeValid_ShouldReturnCorrectResult(int age, bool expectedValue)
        {
            var result = employeeValidation.IsAgeValid(age);

            Assert.That(result, Is.EqualTo(expectedValue));
        }

        [TestCase(false, false)]
        [TestCase(true, true)]
        public void IsEmployeeActive_ShouldReturnCorrectResult(bool isActive, bool expectedValue)
        {
            var result = employeeValidation.IsEmployeeActive(isActive);

            Assert.That(result, Is.EqualTo(expectedValue));
        }

        [TestCase(0, false)]
        [TestCase(1, true)]
        public void HasMinimumExperience_ShouldReturnCorrectResult(int yearsOfExperience, bool expectedValue)
        {
            var result = employeeValidation.HasMinimumExperience(yearsOfExperience);

            Assert.That(result, Is.EqualTo(expectedValue));
        }


        [TestCase(17, ValidationResultType.InvalidAge)]
        [TestCase(30, ValidationResultType.Valid)]
        public void ValidateAge_ShouldReturnCorrectResult(int age, ValidationResultType expectedValue)
        {
            var result = employeeValidation.ValidateAge(age);

            Assert.That(result, Is.EqualTo(expectedValue));
        }


        [TestCase(0, ValidationResultType.InsufficientExperience)]
        [TestCase(3, ValidationResultType.Valid)]
        public void ValidateExperience_ShouldReturnCorrectResult(int yearsOfExperience, ValidationResultType expectedValue)
        {
            var result = employeeValidation.ValidateExperience(yearsOfExperience);

            Assert.That(result, Is.EqualTo(expectedValue));
        }

        [Test]
        public void Validate_ShouldReturnInvalidAge_WhenAgeIsInvalid()
        {
            var employee = new Employee
            {
                Age = 15,
                IsActive = true,
                YearsOfExperience = 5
            };

            var result = employeeValidation.Validate(employee);

            Assert.That(result, Is.EqualTo(ValidationResultType.InvalidAge));
        }

        [Test]
        public void Validate_ShouldReturnInactiveEmployee_WhenEmployeeIsInactive()
        {
            var employee = new Employee
            {
                Age = 30,
                IsActive = false,
                YearsOfExperience = 5
            };

            var result = employeeValidation.Validate(employee);

            Assert.That(result, Is.EqualTo(ValidationResultType.InactiveEmployee));
        }

        [Test]
        public void Validate_ShouldReturnInsufficientExperience_WhenExperienceIsInsufficient()
        {
            var employee = new Employee
            {
                Age = 30,
                IsActive = true,
                YearsOfExperience = 0
            };

            var result = employeeValidation.Validate(employee);

            Assert.That(result, Is.EqualTo(ValidationResultType.InsufficientExperience));
        }

        [Test]
        public void Validate_ShouldReturnValid_WhenAllRulesPass()
        {
            var employee = new Employee
            {
                Age = 30,
                IsActive = true,
                YearsOfExperience = 3
            };

            var result = employeeValidation.Validate(employee);

            Assert.That(result, Is.EqualTo(ValidationResultType.Valid));
        }




    }
}
