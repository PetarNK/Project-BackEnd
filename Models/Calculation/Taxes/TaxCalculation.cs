using log4net;


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

