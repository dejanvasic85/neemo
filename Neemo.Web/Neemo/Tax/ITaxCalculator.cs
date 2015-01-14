namespace Neemo.Tax
{
    public interface ITaxCalculator
    {
        TaxCost CalculateTax(decimal amount);
    }
}