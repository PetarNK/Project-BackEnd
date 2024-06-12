using log4net;
using System;


namespace Backend.Helpers
{
    public class YearCalculator
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(YearCalculator));
        //Method that calculates year difference, taking in account the month and day.
        
        public static int CalculateYearDifference(DateTime startDate, DateTime endDate)
        {
            try
            {
                int years = endDate.Year - startDate.Year;

                // If the end date is earlier in the year than the start date, subtract one year
                if (endDate.Month < startDate.Month ||
                    (endDate.Month == startDate.Month && endDate.Day < startDate.Day))
                {
                    years--;
                }

                return years;
            }
            catch(Exception ex)
            {
                log.Error($"Error while calculating the years {ex.Message}");
                throw;
            }
        }
    }
}
