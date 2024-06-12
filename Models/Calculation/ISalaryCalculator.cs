using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Models
{
    public interface ISalaryCalculator
    {
        void Calculate();
        decimal CalculateNetSalary(int i, int? d);

    }
}
