using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Models
{
    internal class SalaryCalculator : ISalaryCalculator
    {
        private const int MinimumTaxableSalary = 1000;
        private const int MaximumTaxableSalary = 3000;
        private const decimal IncomeTax = 0.1M;
        private const decimal SocialContributionTax = 0.15M;

        public SalaryCalculator()
        {

        }
        

        public void Calculate()
        {
            Console.Write("Gross Salary: ");
            int grossSalary = int.Parse(Console.ReadLine());

            
            decimal netSalary;
            decimal incomeTaxValue;
            decimal socialContributionTaxValue;

            
            if(!(grossSalary <= MinimumTaxableSalary))
            {
                //To include new taxes, just use the method TaxCalculator with the parameters needed.
                //The method can be overloaded to calculate taxes with maximum salary threshold.
                //The method can be used with values or fields and should be called in this scope.

                incomeTaxValue = TaxCalculator(grossSalary, IncomeTax);
                socialContributionTaxValue = TaxCalculator(grossSalary, SocialContributionTax, MaximumTaxableSalary);
                netSalary = grossSalary - (incomeTaxValue + socialContributionTaxValue); 
            }
            else
            {
                netSalary = grossSalary;
            }
            Console.WriteLine($"Your net salary is: {netSalary} IDR\n");

        }
        /// <summary>
        /// Calculates taxes that are dependent on minimum taxable salary
        /// </summary>
        /// <param name="grossSalary">Gross Salary</param>
        /// <param name="taxPercentage">Tax percentage</param>
        /// <returns>Value of money that is going to be removed from the salary, if tax is applied</returns>
        private decimal TaxCalculator(int grossSalary, decimal taxPercentage)
        {
            decimal taxValue;
            taxValue = (grossSalary - MinimumTaxableSalary) * taxPercentage;
            return taxValue;
        }
        /// <summary>
        /// Calculates taxes that are dependent on minimum and maximum taxable salary
        /// </summary>
        /// <param name="grossSalary">Gross Salary</param>
        /// <param name="taxPercentage">Tax percentage</param>
        /// <param name="maximumTaxableSalary">Maximum taxable salary</param>
        /// <returns>Value of money that is going to be removed from the salary, if tax is applied</returns>
        private decimal TaxCalculator(int grossSalary, decimal taxPercentage, int maximumTaxableSalary)
        {
            decimal taxValue;
            taxValue = (grossSalary - MinimumTaxableSalary) * taxPercentage;
            if (grossSalary > maximumTaxableSalary)
            {
                taxValue = (maximumTaxableSalary - MinimumTaxableSalary) * taxPercentage;
            }
            return taxValue;
        }
    }
}
