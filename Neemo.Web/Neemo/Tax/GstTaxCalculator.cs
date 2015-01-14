namespace Neemo.Tax
{
    /// <summary>
    /// Calculates the cost of GST
    /// </summary>
    public class GstTaxCalculator : ITaxCalculator
    {
        private readonly ISysConfig _config;

        public GstTaxCalculator(ISysConfig config)
        {
            _config = config;
        }

        public TaxCost CalculateTax(decimal amount)
        {
            var taxAmount = amount*_config.Gst;
            var amountAfterTax = amount + taxAmount;

            return new TaxCost(amount, taxAmount, amountAfterTax, TaxType.GST);
        }
    }
}