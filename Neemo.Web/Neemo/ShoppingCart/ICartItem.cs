namespace Neemo.ShoppingCart
{
    public interface ICartItem
    {
        int Id { get; }
        int Quantity { get; }
        decimal CalculatePrice();
        void UpdateQuantity(int qty);
    }
}