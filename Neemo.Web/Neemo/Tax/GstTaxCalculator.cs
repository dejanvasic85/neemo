namespace Neemo.Tax
{
    /// <summary>
    /// Calculates the cost of GST
    /// </summary>
    public class GstTaxCalculator : ITaxCalculator
    {
        private const decimal GST = (decimal)0.1;

        public TaxCost CalculateTax(decimal amount)
        {
            var taxAmount = amount*GST;
            var amountAfterTax = amount + taxAmount;

            return new TaxCost(amount, taxAmount, amountAfterTax, TaxType.GST);
        }
    }
}