using Backend.Models.Calculation;
using log4net;
using System;

namespace Backend.Models
{
    public class SalaryCalculator : ISalaryCalculator
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(SalaryCalculator));

        private readonly ISalary _salary;
        private readonly ITaxes _taxes;
        private readonly ITaxCalculation _taxCalculation;

        public SalaryCalculator(ITaxes taxes, ITaxCalculation taxCalculation, ISalary salary)
        {
            _salary = salary;
            _taxes = taxes;
            _taxCalculation = taxCalculation;
        }

        public void Calculate()
        {
            try
            {
                Console.Write("Gross Salary: ");
                if (!int.TryParse(Console.ReadLine(), out int grossSalary) || grossSalary < 0)
                {
                    log.Error("Invalid gross salary input.");
                    throw new ArgumentException("Value should be a positive integer!");
                }
                var (minSalary, maxSalary) = _salary.GetSalaryValues();

                log.Info($"Gross salary input: {grossSalary}");

                decimal netSalary = grossSalary <= minSalary ? grossSalary : CalculateNetSalary(grossSalary, maxSalary);

                log.Info($"Calculated net salary: {netSalary}");

                Console.WriteLine($"Your net salary is: {netSalary} IDR\n");
            }
            catch (ArgumentException ex)
            {
                log.Error("An error occurred during salary calculation.", ex);
                Console.WriteLine(ex.Message);
            }
        }

        public decimal CalculateNetSalary(int grossSalary, int? maxTaxableSalary = null)
        {
            log.Debug($"Calculating net salary for gross salary: {grossSalary}");
            var (minSalary, maxSalary) = _salary.GetSalaryValues();
            int taxableAmountAboveMinimum = grossSalary - minSalary;

            int taxableAmountBetweenMinimumAndMaximum = maxTaxableSalary.HasValue && grossSalary > maxTaxableSalary
                ? maxTaxableSalary.Value - minSalary
                : taxableAmountAboveMinimum;
            
            var (incomeTax, socialTax) = _taxes.GetTaxValues();
            decimal incomeTaxValue = _taxCalculation.CalculateTax(taxableAmountAboveMinimum, incomeTax);
            decimal socialContributionTaxValue = _taxCalculation.CalculateTax(taxableAmountBetweenMinimumAndMaximum, socialTax);

            log.Debug($"Income tax value: {incomeTaxValue}, Social contribution tax value: {socialContributionTaxValue}");

            return grossSalary - (incomeTaxValue + socialContributionTaxValue);
        }
    }
}

