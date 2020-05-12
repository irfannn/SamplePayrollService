using System;

namespace PayrollService.Shared
{
    public class Employee
    {
        public Employee(string firstName, string countryCode)
        {
            if (string.IsNullOrWhiteSpace(firstName))
            {
                throw new ArgumentNullException(nameof(firstName));
            }

            if (string.IsNullOrWhiteSpace(countryCode))
            {
                throw new ArgumentNullException(nameof(countryCode));
            }
            
            FirstName = firstName;
            CountryCode = countryCode;
        }
        public string FirstName { get; }

        public string CountryCode { get; }
    }
}
