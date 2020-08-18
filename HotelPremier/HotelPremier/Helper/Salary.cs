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

        public static decimal CalculateManagerInput(decimal salary, int workExperienc, int qualificationLevel, int genderId)
        {
            decimal result = 0;

            if (genderId == 1)
            {
                result =salary-(decimal)(1000 * 0.75f * workExperienc * 0.15f * qualificationLevel * 1.15f);
            }
            else
            {
                result =salary-(decimal)(1000 * 0.75f * workExperienc * 0.15f * qualificationLevel * 1.12f);
            }
            return result;
        }
    }
}
