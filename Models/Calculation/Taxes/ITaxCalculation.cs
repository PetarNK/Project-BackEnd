namespace Backend.Models.Calculation
{
    public interface ITaxCalculation
    {
        decimal CalculateTax(int taxableAmount,decimal tp);
    }
}
