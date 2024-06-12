﻿using log4net;
using System;

namespace Backend.Models
{
    internal class SalaryCalculator : ISalaryCalculator
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(SalaryCalculator));

        private int minimumTaxableSalary;
        private int maximumTaxableSalary;
        private decimal incomeTaxPercentage;
        private decimal socialContributionTaxPercentage;

        public SalaryCalculator(int minimumSalary, int maximumSalary, decimal incomeTaxPercentage, decimal socialTaxPercentage)
        {
            MinimumTaxableSalary = minimumSalary;
            MaximumTaxableSalary = maximumSalary;
            IncomeTaxPercentage = incomeTaxPercentage;
            SocialContributionTaxPercentage = socialTaxPercentage;
        }

        public int MinimumTaxableSalary
        {
            get => minimumTaxableSalary;
            set
            {
                if (value < 0)
                {
                    log.Error("Attempted to set minimum taxable salary to a negative value.");
                    throw new ArgumentOutOfRangeException(nameof(value), "Salary cannot be less than 0");
                }
                minimumTaxableSalary = value;
                log.Info($"Minimum taxable salary set to {minimumTaxableSalary}");
            }
        }

        public int MaximumTaxableSalary
        {
            get => maximumTaxableSalary;
            set
            {
                if (value < minimumTaxableSalary)
                {
                    log.Error("Attempted to set maximum taxable salary less than minimum taxable salary.");
                    throw new ArgumentOutOfRangeException(nameof(value), "Maximum salary cannot be less than the minimum one!");
                }
                maximumTaxableSalary = value;
                log.Info($"Maximum taxable salary set to {maximumTaxableSalary}");
            }
        }

        public decimal IncomeTaxPercentage
        {
            get => incomeTaxPercentage;
            set
            {
                if (value < 0)
                {
                    log.Error("Attempted to set income tax percentage to a negative value.");
                    throw new ArgumentOutOfRangeException(nameof(value), "Tax percentage cannot be a negative number");
                }
                incomeTaxPercentage = value;
                log.Info($"Income tax percentage set to {incomeTaxPercentage}");
            }
        }

        public decimal SocialContributionTaxPercentage
        {
            get => socialContributionTaxPercentage;
            set
            {
                if (value < 0)
                {
                    log.Error("Attempted to set social contribution tax percentage to a negative value.");
                    throw new ArgumentOutOfRangeException(nameof(value), "Tax percentage cannot be a negative number");
                }
                socialContributionTaxPercentage = value;
                log.Info($"Social contribution tax percentage set to {socialContributionTaxPercentage}");
            }
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

                log.Info($"Gross salary input: {grossSalary}");

                decimal netSalary = grossSalary <= MinimumTaxableSalary ? grossSalary : CalculateNetSalary(grossSalary);

                log.Info($"Calculated net salary: {netSalary}");

                Console.WriteLine($"Your net salary is: {netSalary} IDR\n");
            }
            catch (ArgumentException ex)
            {
                log.Error("An error occurred during salary calculation.", ex);
                Console.WriteLine(ex.Message);
            }
        }

        private decimal CalculateNetSalary(int grossSalary)
        {
            log.Debug($"Calculating net salary for gross salary: {grossSalary}");

            decimal incomeTaxValue = CalculateTax(grossSalary, IncomeTaxPercentage);
            decimal socialContributionTaxValue = CalculateTax(grossSalary, SocialContributionTaxPercentage, MaximumTaxableSalary);

            log.Debug($"Income tax value: {incomeTaxValue}, Social contribution tax value: {socialContributionTaxValue}");

            return grossSalary - (incomeTaxValue + socialContributionTaxValue);
        }

        private decimal CalculateTax(int grossSalary, decimal taxPercentage, int? maxTaxableSalary = null)
        {
            int taxableAmount = maxTaxableSalary.HasValue && grossSalary > maxTaxableSalary
                ? maxTaxableSalary.Value - MinimumTaxableSalary
                : grossSalary - MinimumTaxableSalary;

            log.Debug($"Calculating tax for gross salary: {grossSalary}, tax percentage: {taxPercentage}, taxable amount: {taxableAmount}");

            return taxableAmount * taxPercentage;
        }
    }
}