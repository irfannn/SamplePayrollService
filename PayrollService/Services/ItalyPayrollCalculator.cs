using PayrollService.Base;
using PayrollService.Contracts;

namespace PayrollService.Services
{
    public class ItalyPayrollCalculator : PayrollCalculatorBase
    {
        private double CalculateINPSContribution(double salary)
        {
            ValidateSalary(salary);

            return (salary * 19.19 / 100);
        }

        public override double CalculateIncomeTax(double salary)
        {
            ValidateSalary(salary);

            return (salary * 25.00 / 100);
        }

        public override double CalculateTotalTaxDeductions(double salary)
        {
            ValidateSalary(salary);
            return (CalculateIncomeTax(salary) + CalculateINPSContribution(salary));
        }        
    }
}
