using FluentAssertions;
using NUnit.Framework;
using PayrollService.Common;
using PayrollService.Persistence;
using PayrollService.Services;
using PayrollService.Shared;
using System;

namespace PayrollServiceTests
{
    public class CalculatorTests
    {
        // TODO:

        // InMemory Employee Creaction.
        [Test]
        public void GetEmployeesGrossSalary_GivenCountryCode_Returns_ListOfEmployee()
        {
            // Arrange
            var calculator = new InMemoryPayrollDetailsRepository();
            var countryCode = CountryCode.DEU;
            //Act
            var actual = calculator.GetEmployeesByCountry(countryCode);

            // Assert
            var expected = CountryCode.DEU.ToString();
            actual.Should<Employee>().NotBeEmpty().And.Contain(x => x.CountryCode == expected);
        }

        // Germany class logic
        [Test]
        public void GermanyCalculateIncomeTax25Percent_GivenSalary_Returns_IncomeTaxContributionValue()
        {
            // Arrange
            var calculator = new GermanPayrollCalculator();

            //Act
            var actual = calculator.CalculateIncomeTax(400);

            // Assert
            var expected = 100;
            actual.Should().Be(expected);
        }

        [Test]
        public void GermanyCalculateIncomeTax32Percent_GivenSalary_Returns_IncomeTaxContributionValue()
        {
            // Arrange
            var calculator = new GermanPayrollCalculator();

            //Act
            var actual = calculator.CalculateIncomeTax(600);

            // Assert
            var expected = 192;
            actual.Should().Be(expected);
        }

      
        [Test]
        public void GermanyCalculateTotalTaxDeductions_GivenSalary_Returns_TotalTaxDeductionsValue()
        {
            // Arrange
            var calculator = new GermanPayrollCalculator();

            //Act
            var actual = calculator.CalculateTotalTaxDeductions(600);

            // Assert
            var expected = 204; // TODO:
            actual.Should().Be(expected);
        }

        [Test]
        public void GermanyCalculateIncomeTax_GivenSalaryLessThanZero_Returns_InvalidInputException()
        {
            // Arrange
            var germanSaleryCalculator = new GermanPayrollCalculator();

            //Act
            Action calculateIncomeTax = () => germanSaleryCalculator.CalculateIncomeTax(-100);
            
            Action calculateTotalTaxDeductions = () => germanSaleryCalculator.CalculateTotalTaxDeductions(-200);

            // Assert
            string expectedMessage = "Given salary should be greater than zero, received value:";
            calculateIncomeTax.Should().Throw<InvalidInputException>().Where(e => e.Message.StartsWith(expectedMessage));
            
            calculateTotalTaxDeductions.Should().Throw<InvalidInputException>().Where(e => e.Message.StartsWith(expectedMessage));
        }


        // Spain
        [Test]
        public void SpainCalculatePensionContribution4Percent_GivenSalary_Returns_IncomeTaxContributionValue()
        {
            // Arrange
            var spainSaleryCalculator = new SpainPayrollCalculator();

            //Act
            var actual = spainSaleryCalculator.CalculatePensionContribution(400);

            // Assert
            var expected = 16;
            actual.Should().Be(expected);
        }
               

        [Test]
        public void SpainCalculateIncomeTax25Percent_GivenSalary_Returns_CalculateIncomeTaxValue()
        {
            // Arrange
            var spainSaleryCalculator = new SpainPayrollCalculator();

            //Act
            var actual = spainSaleryCalculator.CalculateIncomeTax(500);

            // Assert
            var expected = 125;
            actual.Should().Be(expected);
        }

        [Test]
        public void SpainCalculateIncomeTax40Percent_GivenSalary_Returns_CalculateIncomeTaxValue()
        {
            // Arrange
            var spainSaleryCalculator = new SpainPayrollCalculator();

            //Act
            var actual = spainSaleryCalculator.CalculateIncomeTax(750);

            // Assert
            var expected = 300;
            actual.Should().Be(expected);
        }

        [Test]
        public void SpainCalculateTotalTaxDeductions_GivenSalary_Returns_TotalTaxDeductionsValue()
        {
            // Arrange
            var calculator = new SpainPayrollCalculator();

            //Act
            var actual = calculator.CalculateTotalTaxDeductions(750);

            // Assert
            var expected = 390; // TODO:
            actual.Should().Be(expected);
        }


        [Test]
        public void SpainCalculateIncomeTax_GivenSalaryLessThanZero_Returns_InvalidInputException()
        {
            // Arrange
            var SpainSaleryCalculator = new SpainPayrollCalculator();

            //Act
            Action calculatePensionContribution = () => SpainSaleryCalculator.CalculatePensionContribution(-100);
            
            Action calculateIncomeTax = () => SpainSaleryCalculator.CalculateIncomeTax(-300);
            Action calculateTotalTaxDeductions = () => SpainSaleryCalculator.CalculateTotalTaxDeductions(-200);

            // Assert
            string expectedMessage = "Given salary should be greater than zero, received value:";
            calculatePensionContribution.Should().Throw<InvalidInputException>().Where(e => e.Message.StartsWith(expectedMessage));
            
            calculateIncomeTax.Should().Throw<InvalidInputException>().Where(e => e.Message.StartsWith(expectedMessage));
            calculateTotalTaxDeductions.Should().Throw<InvalidInputException>().Where(e => e.Message.StartsWith(expectedMessage));
        }

        // Italy
       

        [Test]
        public void ItalyCalculateIncomeTax25Percent_GivenSalary_Returns_CalculateIncomeTaxValue()
        {
            // Arrange
            var ItalySaleryCalculator = new ItalyPayrollCalculator();

            //Act
            var actual = ItalySaleryCalculator.CalculateIncomeTax(500);

            // Assert
            var expected = 125;
            actual.Should().Be(expected);
        }

        // TODO:
        [Test]
        public void ItalyCalculateTotalTaxDeductions_GivenSalary_Returns_TotalTaxDeductionsValue()
        {
            // Arrange
            var calculator = new ItalyPayrollCalculator();

            //Act
            var actual = calculator.CalculateTotalTaxDeductions(600);

            // Assert
            var expected = 265.14; // TODO:
            actual.Should().Be(expected);
        }

        [Test]
        public void ItalyCalculateIncomeTax_GivenSalaryLessThanZero_Returns_InvalidInputException()
        {
            // Arrange
            var italySaleryCalculator = new ItalyPayrollCalculator();

            //Act            
            Action calculateIncomeTax = () => italySaleryCalculator.CalculateIncomeTax(-200);            
            Action calculateTotalTaxDeductions = () => italySaleryCalculator.CalculateTotalTaxDeductions(-200);

            // Assert
            string expectedMessage = "Given salary should be greater than zero, received value:";            
            
            calculateIncomeTax.Should().Throw<InvalidInputException>().Where(e => e.Message.StartsWith(expectedMessage));
            calculateTotalTaxDeductions.Should().Throw<InvalidInputException>().Where(e => e.Message.StartsWith(expectedMessage));
        }

        // Caluclator
        [Test]
        public void ItalyCalculateGrossAmount_GivenSalary_Returns_CalculateGrossAmountValue()
        {
            // Arrange
            var calculator = new GermanPayrollCalculator();

            //Act
            var actual = calculator.CalculateGrossAmount(10,40);

            // Assert
            var expected = 400;
            actual.Should().Be(expected);
        }

        [Test]
        public void ItalyCalculateNetSalary_GivenSalary_Returns_CalculateNetSalaryValue()
        {
            // Arrange
            var calculator = new GermanPayrollCalculator();

            //Act
            var actual = calculator.CalculateNetSalary(500, 60);

            // Assert
            var expected = 440;
            actual.Should().Be(expected);
        }

    }
}
