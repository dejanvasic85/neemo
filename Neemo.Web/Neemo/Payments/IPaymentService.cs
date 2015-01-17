namespace Neemo.Payments
{
    public interface IPaymentService
    {
        PaymentResponse ProcessPaymentForCart(ShoppingCart.Cart cart, string cancelUrl, string returnUrl);
        void CompletePayment(string payerId, string paymentTransactionId);
    }
}
