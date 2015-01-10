namespace Neemo.ShoppingCart
{
    /// <summary>
    /// Wrapper for the current shopping cart in progress for the user
    /// </summary>
    public interface ICartContext
    {
        Cart Current();
        bool HasItemsInCart();
    }
}