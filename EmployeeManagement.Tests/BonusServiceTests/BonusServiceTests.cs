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
        private BonusService bonusService;

        [SetUp]
        public void SetUp()
        {
            bonusService = new BonusService();
        }

        [TestCase(1, 0)]
        [TestCase(3, 500)]
        [TestCase(5, 1000)]
        public void CalculateBonus_ShouldReturnCorrectBonus(int years, decimal expected)
        {
            var bonus = bonusService.CalculateBonus(years);

            Assert.That(bonus, Is.EqualTo(expected));
        }

        [TestCase(-1, false)]
        [TestCase(0, true)]
        [TestCase(5, true)]
        public void IsExperienceValid_ShouldReturnCorrectResult(int yearsOfExperience, bool expectedValue)
        {
            var result = bonusService.IsExperienceValid(yearsOfExperience);

            Assert.That(result, Is.EqualTo(expectedValue));
        }


        [TestCase(1, false)]
        [TestCase(2, true)]
        [TestCase(10, true)]
        public void IsEligibleForBonus_ShouldReturnCorrectResult(int yearsOfExperience, bool expectedValue)
        {
            var result = bonusService.IsEligibleForBonus(yearsOfExperience);

            Assert.That(result, Is.EqualTo(expectedValue));
        }


        [TestCase(-1, 0)]
        [TestCase(1, 0)]
        [TestCase(3, 0.10)]
        [TestCase(6, 0.20)]
        public void GetBonusRate_ShouldReturnCorrectResult(int yearsOfExperience, decimal expectedValue)
        {
            var result = bonusService.GetBonusRate(yearsOfExperience);

            Assert.That(result, Is.EqualTo(expectedValue));
        }

        [TestCase(5000, 3, 500)]
        [TestCase(5000, 6, 1000)]
        [TestCase(0, 0, 0)]
        public void CalculateBonusByRate_ShouldReturnCorrectResult(decimal baseSalary, int yearsOfExperience, decimal expected)
        {
            var result = bonusService.CalculateBonusByRate(baseSalary,yearsOfExperience);

            Assert.That(result, Is.EqualTo(expected));
        }


        [TestCase(3000, 1, 3000)]
        [TestCase(3000, 3, 3500)]
        [TestCase(3000, 6, 4000)]
        public void CalculateTotalSalary_ShouldReturnCorrectResult(decimal baseSalary, int yearsOfExperience, decimal expected)
        {
            var result = bonusService.CalculateTotalSalary(baseSalary, yearsOfExperience);

            Assert.That(result, Is.EqualTo(expected));
        }

        [TestCase(-100, 0)]
        [TestCase(500, 500)]
        [TestCase(2000, 1000)]
        public void NormalizeBonus_ShouldReturnCorrectResult(decimal bonus, decimal expectedValue)
        {
            var result = bonusService.NormalizeBonus(bonus);

            Assert.That(result, Is.EqualTo(expectedValue));
        }

        [Test]
        public void GetMaxPossibleBonus_ShouldReturnCorrectResult()
        {
            var result = bonusService.GetMaxPossibleBonus();

            Assert.That(result, Is.EqualTo(1000));
        }

        [Test]
        public void GetMinPossibleBonus_ShouldReturnCorrectResult()
        {
            var result = bonusService.GetMinPossibleBonus();

            Assert.That(result, Is.EqualTo(0));
        }


    }
}
