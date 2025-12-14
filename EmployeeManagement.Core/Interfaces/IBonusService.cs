using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Core.Interfaces
{
    public interface IBonusService
    {
        decimal CalculateBonus(int yearsOfExperience);
        bool IsEligibleForBonus(int yearsOfExperience);
        decimal GetBonusRate(int yearsOfExperience);
        decimal CalculateBonusByRate(decimal baseSalary, int yearsOfExperience);
        decimal CalculateTotalSalary(decimal baseSalary, int yearsOfExperience);
        bool HasMinimumExperience(int yearsOfExperience);
        bool IsSeniorEmployee(int yearsOfExperience);
        decimal GetMaxPossibleBonus();
        decimal GetMinPossibleBonus();
        bool IsBonusApplicable(decimal baseSalary);
        decimal NormalizeBonus(decimal bonus);
        bool IsExperienceValid(int yearsOfExperience);
    }
}
