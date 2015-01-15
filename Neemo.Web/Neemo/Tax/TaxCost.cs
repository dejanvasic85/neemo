namespace Neemo.Tax
{
    public sealed class TaxCost
    {
        public TaxCost(TaxType taxType)
        {
            this.TaxType = taxType;
        }

        public TaxCost(decimal beforeTaxAmount, decimal taxAmount, decimal amountAfterTax, TaxType taxType)
        {
            BeforeTaxAmount = beforeTaxAmount;
            TaxAmount = taxAmount;
            AmountAfterTax = amountAfterTax;
            TaxType = taxType;
        }

        public decimal BeforeTaxAmount { get; private set; }
        public decimal TaxAmount { get; private set; }
        public decimal AmountAfterTax { get; private set; }
        public TaxType TaxType { get; private set; }

        public static implicit operator decimal(TaxCost taxCost)
        {
            if (taxCost == null)
                return 0;

            return taxCost.TaxAmount;
        }

        public static TaxCost operator +(TaxCost tax1, TaxCost tax2)
        {
            if (tax1.TaxType != tax2.TaxType)
                throw new TaxNotTheSameException("Unable to sum two taxes when they are not the same type");

            return new TaxCost(
                tax1.BeforeTaxAmount + tax2.BeforeTaxAmount,
                tax1.TaxAmount + tax2.TaxAmount,
                tax1.AmountAfterTax + tax2.AmountAfterTax,
                tax1.TaxType
                );
        }

        public static TaxCost operator *(TaxCost tax1, decimal amountToMultiply)
        {
            return new TaxCost(
                tax1.BeforeTaxAmount * amountToMultiply,
                tax1.TaxAmount * amountToMultiply,
                tax1.AmountAfterTax * amountToMultiply,
                tax1.TaxType
                );
        }
    }
}