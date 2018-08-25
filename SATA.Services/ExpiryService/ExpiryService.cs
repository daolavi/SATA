using System;
using System.Collections.Generic;
using System.Text;

namespace SATA.Services.ExpiryService
{
    public class ExpiryService : IExpiryService
    {
        public bool IsLeapYear(string expiryDate)
        {
            var year = int.Parse(expiryDate.Substring(2, 4));
            return DateTime.IsLeapYear(year);
        }

        public bool IsPrimeNumber(string expiryDate)
        {
            var year = int.Parse(expiryDate.Substring(2, 4));

            if (year == 1)
                return false;

            if (year == 2)
                return true;

            for (int i = 2; i <= Math.Ceiling(Math.Sqrt(year)); ++i)
            {
                if (year % i == 0)
                    return false;
            }

            return true;
        }
    }
}
