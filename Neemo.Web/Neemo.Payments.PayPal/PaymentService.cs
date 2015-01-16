namespace Neemo.Payments.pp
{
    using ShoppingCart;

    public class PaymentService : IPaymentService
    {
        public PaymentResponse ProcessPaymentForCart(Cart cart)
        {
            var apiContext = ApiContextFactory.Create();

            //var paypalItems = new ItemList
            //{
            //    items = request.PriceBreakdown.LineItems.Select(li => new Item
            //    {
            //        name = li.Key,
            //        price = li.Value.ToString("N"),
            //        currency = "AUD",
            //        quantity = "1",
            //        sku = request.PayReference
            //    }).ToList()
            //};
            
            //// ###Payer
            //// A resource representing a Payer that funds a payment
            //// Payment Method
            //// as `paypal`
            //var payer = new Payer { payment_method = "paypal" };

            //// # Redirect URLS
            //var redirUrls = new RedirectUrls
            //{
            //    cancel_url = request.CancelUrl,
            //    return_url = request.ReturnUrl
            //};

            //// ###Details
            //// Let's you specify details of a payment amount.
            //var details = new Details
            //{
            //    tax = "0",
            //    shipping = "0",
            //    subtotal = request.PriceBreakdown.Total.ToString("N"),
            //};

            //// ###Amount
            //// Let's you specify a payment amount.
            //var amount = new Amount
            //{
            //    currency = "AUD",
            //    total = request.PriceBreakdown.Total.ToString("N"), // Total must be equal to sum of shipping, tax and subtotal.
            //    details = details
            //};

            //// ###Transaction
            //// A transaction defines the contract of a
            //// payment - what is the payment for and who
            //// is fulfilling it. 
            //var transactionList = new List<Transaction>
            //{
            //    new Transaction
            //    {
            //        description = "Testing out the paypal API Integration.",
            //        amount = amount,
            //        item_list = paypalItems
            //    }
            //};

            //// The Payment creation API requires a list of
            //// Transaction; add the created `Transaction`
            //// to a List

            //// ###Payment
            //// A Payment Resource; create one using
            //// the above types and intent as `sale` or `authorize`
            //var payment = new Payment
            //{
            //    intent = "sale",
            //    payer = payer,
            //    transactions = transactionList,
            //    redirect_urls = redirUrls
            //};

            //var myResponse = payment.Create(apiContext);

            //if (myResponse == null || myResponse.links == null)
            //    return new PaymentResponse { Status = PaymentStatus.Failed };

            //var approvalUrl = myResponse.links.FirstOrDefault(lnk => lnk.rel.Equals("approval_url", StringComparison.OrdinalIgnoreCase));
            //if (approvalUrl == null)
            //    return new PaymentResponse { Status = PaymentStatus.Failed };

            //return new PaymentResponse
            //{
            //    Status = PaymentStatus.ApprovalRequired,
            //    ApprovalUrl = approvalUrl.href,
            //    PaymentId = myResponse.id
            //};



            return new PaymentResponse(PaymentStatus.Complete, "", new { });
        }
    }
}
