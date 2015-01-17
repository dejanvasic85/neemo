namespace Neemo.Payments
{
    public class PaymentResponse
    {
        public static PaymentResponse Failed()
        {
            return new PaymentResponse { Status = PaymentStatus.Failed };
        }

        public static PaymentResponse Completed(string paymentUrl, string transactionId)
        {
            return new PaymentResponse { Status = PaymentStatus.Complete, PaymentUrl = paymentUrl, TransactionId = transactionId};
        }

        public PaymentStatus Status { get; private set; }
        public string TransactionId { get; private set; }
        public string PaymentUrl { get; private set; }
    }
}