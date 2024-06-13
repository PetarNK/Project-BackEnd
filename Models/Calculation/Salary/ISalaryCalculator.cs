namespace Backend.Models
{
    public interface ISalaryCalculator
    {
        void Calculate();
        decimal CalculateNetSalary(int i, int? d);

    }
}
