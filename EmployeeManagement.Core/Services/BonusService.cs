using EmployeeManagement.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Core.Services
{
    public class BonusService : IBonusService
    {
        public decimal CalculateBonus(int yearsOfExperience)
        {
            if (!IsExperienceValid(yearsOfExperience))
                return 0;

            if (!IsEligibleForBonus(yearsOfExperience))
                return 0;

            if (yearsOfExperience < 5)
                return 500;

            return 1000;
        }

        public bool IsEligibleForBonus(int yearsOfExperience)
        {
            return yearsOfExperience >= 2;
        }

        public decimal GetBonusRate(int yearsOfExperience)
        {
            if (!IsExperienceValid(yearsOfExperience))
                return 0;

            if (yearsOfExperience < 2)
                return 0;

            if (yearsOfExperience < 5)
                return 0.10m;

            return 0.20m;
        }

        public decimal CalculateBonusByRate(decimal baseSalary, int yearsOfExperience)
        {
            if (!IsBonusApplicable(baseSalary))
                return 0;

            var rate = GetBonusRate(yearsOfExperience);
            return baseSalary * rate;
        }

        public decimal CalculateTotalSalary(decimal baseSalary, int yearsOfExperience)
        {
            var bonus = CalculateBonus(yearsOfExperience);
            return baseSalary + bonus;
        }

        public bool HasMinimumExperience(int yearsOfExperience)
        {
            return yearsOfExperience >= 1;
        }

        public bool IsSeniorEmployee(int yearsOfExperience)
        {
            return yearsOfExperience >= 7;
        }

        public decimal GetMaxPossibleBonus()
        {
            return 1000;
        }

        public decimal GetMinPossibleBonus()
        {
            return 0;
        }

        public bool IsBonusApplicable(decimal baseSalary)
        {
            return baseSalary > 0;
        }

        public decimal NormalizeBonus(decimal bonus)
        {
            if (bonus < GetMinPossibleBonus())
                return GetMinPossibleBonus();

            if (bonus > GetMaxPossibleBonus())
                return GetMaxPossibleBonus();

            return bonus;
        }

        public bool IsExperienceValid(int yearsOfExperience)
        {
            return yearsOfExperience >= 0;
        }
    }
}
