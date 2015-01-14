namespace Neemo.Payments
{
    public class PaymentResponse
    {
        public PaymentResponse(PaymentStatus status, string transactionId, object paymentDetails = null)
        {
            Status = status;
            TransactionId = transactionId;
            PaymentDetails = paymentDetails;
        }

        public PaymentStatus Status { get; set; }
        public string TransactionId { get; set; }
        public object PaymentDetails { get; set; }
    }
}