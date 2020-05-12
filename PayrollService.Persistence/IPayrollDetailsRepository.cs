using PayrollService.Shared;
using System.Collections.Generic;

namespace PayrollService.Persistence
{
    public interface IPayrollDetailsRepository
    {
        IEnumerable<Employee> GetEmployeesByCountry(CountryCode country);
    }
}
