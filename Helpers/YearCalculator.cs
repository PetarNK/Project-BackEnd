using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Helpers
{
    public class YearCalculator
    {
        //Method that calculates year difference, taking in account the month and day.
        public static int CalculateYearDifference(DateTime startDate, DateTime endDate)
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
    }
}
