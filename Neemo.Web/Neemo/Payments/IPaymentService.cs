namespace Neemo.Payments
{
    public interface IPaymentService
    {
        PaymentResponse ProcessPaymentForCart(ShoppingCart.Cart cart, string cancelUrl, string returnUrl);
        void CompletePayment(string paymentTransactionId, string payerId);
    }
}
