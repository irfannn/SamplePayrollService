using PayrollService.Common;
using PayrollService.Contracts;

namespace PayrollService.Base
{
    public abstract class PayrollCalculatorBase : IPayrollCalculator
    {
        public abstract double CalculateIncomeTax(double salary);

        public abstract double CalculateTotalTaxDeductions(double salary);

        public virtual double CalculateGrossAmount(double hourlyRate, double numberOfHoursWork)
        {
            if (hourlyRate < 0 || numberOfHoursWork < 0)
            {
                throw new InvalidInputException($"Given hourlyRate/numberOfHoursWork should be greater than zero, received value:{hourlyRate}/{numberOfHoursWork}");
            }
            return (hourlyRate * numberOfHoursWork);
        }

        public virtual double CalculateNetSalary(double salary, double taxDeductions)
        {
            ValidateSalary(salary);

            return (salary - taxDeductions);
        }

        protected virtual void ValidateSalary(double salary)
        {
            if (salary < 0)
            {
                throw new InvalidInputException($"Given salary should be greater than zero, received value:{salary}");
            }
        }
    }
}
