namespace Neemo.ShoppingCart
{
    using Tax;
    public interface ICartItem
    {
        string LineItemId { get; }
        int Id { get; }
        decimal Price { get; }
        decimal PriceWithoutTax { get; }
        int Quantity { get; }
        string Title { get; }

        decimal CalculateSubTotal();
        decimal CalculateSubTotalWithoutTax();
        
        TaxCost CalculateTaxPerItem();
        TaxCost CalculateTotalTax();

        void UpdateQuantity(int qty);
    }
}