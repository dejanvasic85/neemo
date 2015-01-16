
namespace Neemo.Payments.PayPal
{
    using ShoppingCart;

    public class PaymentService : IPaymentService
    {
        public PaymentResponse ProcessPaymentForCart(Cart cart)
        {
            return new PaymentResponse(PaymentStatus.Complete, "", new { });
        }
    }
}
