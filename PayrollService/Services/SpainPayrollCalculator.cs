using PayrollService.Base;
using PayrollService.Contracts;

namespace PayrollService.Services
{
    public class SpainPayrollCalculator : PayrollCalculatorBase
    {
        public double CalculatePensionContribution(double salary)
        {
            ValidateSalary(salary);

            return (salary * 4.00 / 100);
        }

        private double CalculateUniversalSocialChargeContribution(double salary)
        {
            ValidateSalary(salary);

            if (salary <= 500)
            {
                return (salary * 7.00 / 100);
            }
            return (salary * 8.00 / 100);

        }

        public override double CalculateIncomeTax(double salary)
        {
            ValidateSalary(salary);

            if (salary <= 600)
            {
                return (salary * 25.00 / 100);
            }

            return (salary * 40.00 / 100);
        }

        public override double CalculateTotalTaxDeductions(double salary)
        {
            ValidateSalary(salary);
            return (CalculateIncomeTax(salary) + CalculateUniversalSocialChargeContribution(salary) + CalculatePensionContribution(salary));
        }
    }
}
