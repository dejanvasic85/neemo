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

        public TaxCost CalculateForAmountExcludingTax(decimal beforeTaxAmount)
        {
            var taxAmount = beforeTaxAmount * _config.Gst;
            var amountAfterTax = beforeTaxAmount + taxAmount;

            return new TaxCost(beforeTaxAmount, taxAmount, amountAfterTax, TaxType.GST);
        }

        public TaxCost CalculateForAmountIncludingTax(decimal afterTaxAmount)
        {
            //var beforeTaxAmount = (1 - _config.Gst) * afterTaxAmount;
            //var taxAmount = afterTaxAmount - beforeTaxAmount;

            var beforeTaxAmount = afterTaxAmount / (1 + _config.Gst);
            var taxAmount = afterTaxAmount - beforeTaxAmount;

            return new TaxCost(beforeTaxAmount, taxAmount, afterTaxAmount, TaxType.GST);
        }
    }
}