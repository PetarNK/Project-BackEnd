using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Models.Calculation
{
    public class TaxCalculation : ITaxCalculation
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(TaxCalculation));


        public decimal CalculateTax(int taxableAmount, decimal taxPercentage)
        {

            log.Debug($"Calculating tax for gross salary: {taxableAmount}, tax percentage: {taxPercentage}");

            return taxableAmount * taxPercentage;
        }
    }
    }

