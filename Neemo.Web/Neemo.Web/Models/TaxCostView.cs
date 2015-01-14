namespace Neemo.Web.Models
{
    public class TaxCostView
    {
        public decimal BeforeTaxAmount { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal AfterTaxAmountAfterTax { get; set; }
        public string TaxType { get; set; }
    }
}