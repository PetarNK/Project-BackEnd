using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Models
{
    internal class SalaryCalculator
    {
        private const int MinimumTaxableSalary = 1000;
        private const int MaximumTaxableSalary = 3000;
        private const decimal IncomeTax = 0.1M;
        private const decimal SocialContributionTax = 0.15M;
        

        public void Calculate()
        {
            Console.Write("Gross Salary: ");
            int grossSalary = int.Parse(Console.ReadLine());

            decimal netSalary;
            decimal incomeTaxValue;
            decimal socialContributionTaxValue;

            
            if(!(grossSalary <= MinimumTaxableSalary))
            {            
                incomeTaxValue = (grossSalary - MinimumTaxableSalary)*IncomeTax;

                if (grossSalary>MaximumTaxableSalary)
                {
                    socialContributionTaxValue = (MaximumTaxableSalary - MinimumTaxableSalary)*SocialContributionTax;
                }
                else
                {
                    socialContributionTaxValue = (grossSalary - MinimumTaxableSalary) * SocialContributionTax;
                }

                netSalary = grossSalary - (incomeTaxValue + socialContributionTaxValue); 
            }
            else
            {
                netSalary = grossSalary;
            }
            Console.WriteLine($"Your net salary is: {netSalary} IDR\n");

        }
        //private decimal TaxCalculator(decimal taxPercentage) 
        //{
            

        //}
    }
}
