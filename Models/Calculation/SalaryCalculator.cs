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
        private int minimumTaxableSalary;
        private int maximumTaxableSalary;
        private decimal incomeTax;
        private decimal socialContributionTax;

        public SalaryCalculator(int minimumSalary, int maximumSalary, decimal incomeTaxPercentage, decimal socialTaxPercentage)
        {
            this.MinimumTaxableSalary = minimumSalary;
            this.MaximumTaxableSalary = maximumSalary;
            this.IncomeTaxProcentage = incomeTaxPercentage;
            this.SocialContributionTax= socialTaxPercentage;
        }
        public int MinimumTaxableSalary
        {
            get => minimumTaxableSalary; 
            set
            {
                if (value < 0) 
                {
                    throw new ArgumentOutOfRangeException("Salary cannot be less than 0");
                }
                minimumTaxableSalary = value;
            }
        }
        public int MaximumTaxableSalary
        {
            get => maximumTaxableSalary;
            set
            {
                if (value < maximumTaxableSalary)
                {
                    throw new ArgumentOutOfRangeException("Maximum salary cannot be less than the minimum one!");
                }
                maximumTaxableSalary = value;
            }
        }

        public decimal IncomeTaxProcentage { get => incomeTax; 
            set
            {
                if(value < 0)
                {
                    throw new ArgumentOutOfRangeException("Tax percentage cannot be negative number");
                }
                incomeTax = value;
            }
        }
        public decimal SocialContributionTax
        {
            get => socialContributionTax;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Tax percentage cannot be negative number");
                }
                socialContributionTax = value;
            }
        }



        public void Calculate()
        {
            try
            {


                Console.Write("Gross Salary: ");
                int grossSalary = int.Parse(Console.ReadLine());

                if (grossSalary < 0)
                {
                    throw new ArgumentOutOfRangeException("Salary cannot be less than 0");
                }



                decimal netSalary;
                decimal incomeTaxValue;
                decimal socialContributionTaxValue;


                if (!(grossSalary <= MinimumTaxableSalary))
                {
                    //To include new taxes, just use the method TaxCalculator with the parameters needed.
                    //The method can be overloaded to calculate taxes with maximum salary threshold.
                    //The method can be used with values or fields and should be called in this scope.

                    incomeTaxValue = CalculatorWithoutMaximumThreshold(grossSalary, IncomeTaxProcentage);
                    socialContributionTaxValue = CalculatorWithMaximumThreshold(grossSalary, SocialContributionTax, MaximumTaxableSalary);
                    netSalary = grossSalary - (incomeTaxValue + socialContributionTaxValue);
                }
                else
                {
                    netSalary = grossSalary;
                }
                Console.WriteLine($"Your net salary is: {netSalary} IDR\n");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        /// <summary>
        /// Calculates taxes that are dependent on minimum taxable salary
        /// </summary>
        /// <param name="grossSalary">Gross Salary</param>
        /// <param name="taxPercentage">Tax percentage</param>
        /// <returns>Value of money that is going to be removed from the salary, if tax is applied</returns>
        decimal CalculatorWithoutMaximumThreshold(int grossSalary, decimal taxPercentage)
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
        decimal CalculatorWithMaximumThreshold(int grossSalary, decimal taxPercentage, int maximumTaxableSalary)
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
