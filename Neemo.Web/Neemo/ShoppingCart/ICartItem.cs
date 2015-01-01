namespace Neemo.ShoppingCart
{
    public interface ICartItem
    {
        string LineItemId { get; }
        int Id { get; }
        int Quantity { get; }
        decimal CalculatePrice();
        void UpdateQuantity(int qty);
    }
}