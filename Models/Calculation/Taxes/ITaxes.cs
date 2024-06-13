namespace Backend.Models.Calculation
{
    public interface ITaxes
    {
        (decimal, decimal) GetTaxValues();
        decimal GetNewTaxValue();
    }
}
