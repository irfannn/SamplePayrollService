using PayrollService.Contracts;
using PayrollService.Services;
using PayrollService.Shared;
using System;

namespace PayrollService
{    
    public class CalculatorFactory : ICalculatorFactory
    {
        public IPayrollCalculator Create(CountryCode countryCode)
        {
            switch (countryCode)
            {
                case CountryCode.DEU:
                    return new GermanPayrollCalculator();
                case CountryCode.ESP:
                    return new SpainPayrollCalculator();
                case CountryCode.ITA:
                    return new ItalyPayrollCalculator();
                default:
                    throw new InvalidOperationException($"Not supported country code, received value:{countryCode}");                    
            }
        }
    }
}
