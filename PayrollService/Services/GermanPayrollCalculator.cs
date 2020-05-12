using PayrollService.Base;

namespace PayrollService.Services
{
    public class GermanPayrollCalculator : PayrollCalculatorBase
    {
        public override double CalculateIncomeTax(double salary)
        {
            ValidateSalary(salary);

            if (salary <= 400)
            {
                return (salary * 25.00 / 100);
            }
            return (salary * 32.00 / 100);
        }

        private double CalculatePensionContribution(double salary)
        {
            ValidateSalary(salary);
            return (salary * 2.00 / 100);
        }
                
        public override double CalculateTotalTaxDeductions(double salary)
        {
            ValidateSalary(salary);
            return (CalculateIncomeTax(salary) + CalculatePensionContribution(salary));
        }
    }
}
