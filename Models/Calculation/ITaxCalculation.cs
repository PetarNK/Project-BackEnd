using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Models.Calculation
{
    public interface ITaxCalculation
    {
        decimal CalculateTax(int taxableAmount,decimal tp);
    }
}
