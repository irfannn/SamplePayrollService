using PayrollService.Shared;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PayrollService.Persistence
{
    public class InMemoryPayrollDetailsRepository : IPayrollDetailsRepository
    {
        public IEnumerable<Employee> GetEmployeesByCountry(CountryCode country)
        {
            var employees = new List<Employee>
            {
                new Employee("Rock1",CountryCode.DEU.ToString()),            
                new Employee("Rock2",CountryCode.ESP.ToString()),
                new Employee("Rock3",CountryCode.ITA.ToString())
            };
                        
            return employees.Where(e => e.CountryCode.Equals(country.ToString(),StringComparison.InvariantCultureIgnoreCase));
        }
    }
}
