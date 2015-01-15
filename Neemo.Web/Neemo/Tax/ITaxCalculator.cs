namespace Neemo.Tax
{
    public interface ITaxCalculator
    {
        /// <summary>
        /// Returns the TaxCosts for the amount that does not have the tax included
        /// </summary>
        TaxCost CalculateForAmountExcludingTax(decimal beforeTaxAmount);

        /// <summary>
        /// Returns the TaxCosts for the amount that already has tax included
        /// </summary>
        TaxCost CalculateForAmountIncludingTax(decimal afterTaxAmount);
    }
}