using System.Collections.Generic;

namespace PayrollService.Contracts
{
    public interface IPayrollCalculator
    {
        double CalculateGrossAmount(double hourlyRate, double numberOfHoursWork);
        double CalculateNetSalary(double salary, double taxDeductions);
        double CalculateIncomeTax(double salary);
        double CalculateTotalTaxDeductions(double salary);

    }
}