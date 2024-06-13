namespace Backend.Models.Calculation
{
    public class Salary : ISalary
    {
        private int minimumTaxableSalary = 1000;
        private int maximumTaxableSalary = 3000;
       

        public int MinimumTaxableSalary
        {
            get { return minimumTaxableSalary; }
        }

        public int MaximumTaxableSalary
        {
            get { return maximumTaxableSalary; }
        }

        public (int, int) GetSalaryValues()
        {
            return (MinimumTaxableSalary, MaximumTaxableSalary);
        }
    }
}
