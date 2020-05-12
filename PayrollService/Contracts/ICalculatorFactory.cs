using PayrollService.Contracts;
using PayrollService.Shared;

namespace PayrollService.Contracts
{
    public interface ICalculatorFactory
    {
        IPayrollCalculator Create(CountryCode countryCode);
    }
}
