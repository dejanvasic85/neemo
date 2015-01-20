namespace Neemo.Orders
{
    public interface IOrderService
    {
        Order CreateOrder(ShoppingCart.Cart cart);
    }
}