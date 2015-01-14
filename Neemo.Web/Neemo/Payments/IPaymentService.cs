namespace Neemo.Payments
{
    public interface IPaymentService
    {
        PaymentResponse ProcessPaymentForCart(ShoppingCart.Cart cart);
    }
}
