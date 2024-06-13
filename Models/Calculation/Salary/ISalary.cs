namespace Backend.Models.Calculation
{
    public interface ISalary
    {
        (int, int) GetSalaryValues();
    }
}
