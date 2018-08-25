using System;
using System.Collections.Generic;
using System.Text;

namespace SATA.Services.ExpiryService
{
    public interface IExpiryService
    {
        bool IsPrimeNumber(string expiryDate);

        bool IsLeapYear(string expiryDate);
    }
}
