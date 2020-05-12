# SamplePayrollService

Endpoint:
https://localhost:{port}/api/PayrollService/deu

Please replace the port accordingly.

Input Data:
{
	"CountryCode": "ITA",
	"HourlyRate":  "10",
	"HoursWorked": "20"
}

Please provide different input parameter values to get different output data.

Output:
{
    "CountryCode": "ITA",
    "GrossSalary": 200.0,
    "TaxesDeductions": 88.38,
    "NetSalary": 111.62
}
