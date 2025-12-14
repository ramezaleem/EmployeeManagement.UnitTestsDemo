using EmployeeManagement.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Tests.BonusServiceTests
{
    [TestFixture]
    public class BonusServiceTests
    {
        BonusService bonusService;

        [SetUp]
        public void SetUp()
        {
            bonusService = new BonusService();
        }

        //[Test]
        //public void CheckBonusForEmployeeLessThan2Years_ShouldReturnCorrectBonus()
        //{
        //    var yearsOfExperience = 1;

        //    var bonus = bonusService.CalculateBonus(yearsOfExperience);
        //    Assert.That(bonus, Is.EqualTo(0m));
        //}

        //[Test]
        //public void CheckBonusForEmployeeBetween2And5Years_ShouldReturnCorrectBonus()
        //{
        //    var yearsOfExperience = 3;


        //    var bonus = bonusService.CalculateBonus(yearsOfExperience);
        //    Assert.That(bonus, Is.EqualTo(500m));
        //}

        //[Test]
        //public void CheckBonusForEmployeeEqualOrGreaterThan5Years_ShouldReturnCorrectBonus()
        //{
        //    var yearsOfExperience = 5;


        //    var bonus = bonusService.CalculateBonus(yearsOfExperience);
        //    Assert.That(bonus, Is.EqualTo(1000m));
        //}


        [TestCase(1, 0)]
        [TestCase(3, 500)]
        [TestCase(5, 1000)]
        public void CalculateBonus_ShouldReturnCorrectBonus(int years, decimal expected)
        {
            var bonus = bonusService.CalculateBonus(years);

            Assert.That(bonus, Is.EqualTo(expected));
        }


    }
}
