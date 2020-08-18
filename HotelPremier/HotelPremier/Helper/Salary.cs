using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelPremier.Helper
{
    public class Salary
    {
        public static decimal SalaryCalculate(int workExpirienc, int qualificationLevel, int genderId, decimal inputSalary)
        {
            decimal result = 0;
            
            if( genderId==1)
            {
                result = (decimal)(1000 * 0.75f * workExpirienc * 0.15f * qualificationLevel * 1.15f)+inputSalary;
            }
            else
            {
                result = (decimal)(1000 * 0.75f * workExpirienc * 0.15f * qualificationLevel * 1.12f) + inputSalary;
            }
            return result;
        }
    }
}
