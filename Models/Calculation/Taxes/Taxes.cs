namespace Backend.Models.Calculation
{
    public class Taxes:ITaxes
    {
        private readonly decimal incomeTaxPercentage = 0.10M;
        private readonly decimal socialContributionTaxPercentage = 0.15M;

        public decimal IncomeTaxPercentage
        {
            get { return incomeTaxPercentage; }
        }

        public decimal SocialContributionTaxPercentage
        {
            get { return socialContributionTaxPercentage; }
        }

        public (decimal, decimal) GetTaxValues()
        {
            return (IncomeTaxPercentage, SocialContributionTaxPercentage);
        }
        public decimal GetNewTaxValue()
        {
            return 0;
        }

    }
}
