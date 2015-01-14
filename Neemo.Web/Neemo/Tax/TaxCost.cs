namespace Neemo.Tax
{
    public class TaxCost
    {
        public TaxCost(decimal beforeTaxAmount, decimal taxAmount, decimal amountAfterTax, TaxType taxType)
        {
            BeforeTaxAmount = beforeTaxAmount;
            TaxAmount = taxAmount;
            AfterTaxAmountAfterTax = amountAfterTax;
            TaxType = taxType;
        }

        public decimal BeforeTaxAmount { get; private set; }
        public decimal TaxAmount { get; private set; }
        public decimal AfterTaxAmountAfterTax { get; private set; }
        public TaxType TaxType { get; private set; }
    }
}