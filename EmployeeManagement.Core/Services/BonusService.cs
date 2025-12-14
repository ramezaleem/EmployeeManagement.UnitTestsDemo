using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Core.Services
{
    public class BonusService
    {
        public decimal CalculateBonus(int yearsOfExperience)
        {
            if (yearsOfExperience < 2)
                return 0;

            if (yearsOfExperience < 5)
                return 500;

            return 1000;
        }
    }
}
