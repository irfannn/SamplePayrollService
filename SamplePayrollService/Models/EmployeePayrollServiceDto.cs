using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SamplePayrollService.Models
{
    public class EmployeePayrollServiceDto
    {
        // TODO:
        public string CountryCode { get; set; }

        public double GrossSalary { get; set; }

        public double TaxesDeductions { get; set; }

        public double NetSalary { get; set; }
    }
}