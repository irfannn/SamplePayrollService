using PayrollService.Common;
using PayrollService.Contracts;
using PayrollService.Persistence;
using PayrollService.Shared;
using SamplePayrollService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;


namespace SamplePayrollService.Controllers
{
    [RoutePrefix("api/[controller]/{countrycode}")]
    public class PayrollServiceController : ApiController
    {
        private readonly ICalculatorFactory factory;
        private readonly IPayrollDetailsRepository payrollDetailsRepository;

        public PayrollServiceController(ICalculatorFactory factory, IPayrollDetailsRepository payrollDetailsRepository)
        {
            this.factory = factory;
            this.payrollDetailsRepository = payrollDetailsRepository;
        }

        [HttpGet]
        public IHttpActionResult Get(InputDataDto input)
        {

            var isValidCountryCode = Enum.TryParse(input.CountryCode, true, out CountryCode countryCodes);

            if (input is null || !isValidCountryCode) return BadRequest("Invalid input received, please provide valid input and try again!!");

            try // Global error handling not implemented because of the limited scope of the project
            {                
                var employees = payrollDetailsRepository.GetEmployeesByCountry(countryCodes);
                
                double salery = 0;
                double taxDeducations = 0;
                double netSalery = 0;
                
                var calculator = factory.Create(countryCodes);
                var result = new List<EmployeePayrollServiceDto>();

                foreach (var employee in employees)
                {
                    salery = calculator.CalculateGrossAmount(input.HourlyRate, input.HoursWorked);
                    taxDeducations = calculator.CalculateTotalTaxDeductions(salery);                    
                    netSalery = calculator.CalculateNetSalary(salery, taxDeducations);

                    result.Add(new EmployeePayrollServiceDto 
                    { 
                        CountryCode = employee.CountryCode, 
                        GrossSalary = salery, 
                        NetSalary = netSalery, 
                        TaxesDeductions = taxDeducations
                    });
                }

                return this.Json(result.AsEnumerable());
            }
            catch (InvalidInputException e)
            {
                return this.BadRequest(e.Message);
            }
            catch(Exception)
            {
                return StatusCode(HttpStatusCode.InternalServerError);
            }            
        }
    
    
    }
}
