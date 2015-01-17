using System;
using System.Collections.Generic;
using System.Linq;
using Neemo.Store;
using Neemo.ShoppingCart;
using PayPal.Api.Payments;

namespace Neemo.Payments.pp
{
    public class PaymentService : IPaymentService
    {
        public PaymentResponse ProcessPaymentForCart(Cart cart, string cancelUrl, string returnUrl)
        {
            var apiContext = ApiContextFactory.Create();

            var paypalItems = new ItemList
            {
                items = cart.GetItems().OfType<ProductCartItem>().Select(li => new Item
                {
                    name = li.Title,
                    price = li.Price.ToString("N"),
                    currency = "AUD",
                    quantity = li.Quantity.ToString(),
                    sku = li.LineItemId
                }).ToList()
            };

            // ###Payer
            // A resource representing a Payer that funds a payment
            // Payment Method
            // as `paypal`
            var payer = new Payer { payment_method = "paypal" };

            //// # Redirect URLS
            var redirUrls = new RedirectUrls
            {
                cancel_url = cancelUrl,
                return_url = returnUrl
            };

            // ###Details
            // Let's you specify details of a payment amount.
            var details = new Details
            {
                tax = cart.CalculateTotalTax().TaxAmount.ToString("N"),
                shipping = cart.ShippingCost.Cost.ToString("N"),
                subtotal = cart.CalculateSubTotalWithoutTax().ToString("N"),
            };

            // ###Amount
            // Let's you specify a payment amount.
            var amount = new Amount
            {
                currency = "AUD",
                total = cart.CalculateGrandTotal().ToString("N"), // Total must be equal to sum of shipping, tax and subtotal.
                details = details
            };

            // ###Transaction
            // A transaction defines the contract of a
            // payment - what is the payment for and who
            // is fulfilling it. 
            var transactionList = new List<Transaction>
            {
                new Transaction
                {
                    description = "Testing out the paypal API Integration.",
                    amount = amount,
                    item_list = paypalItems
                }
            };

            // The Payment creation API requires a list of
            // Transaction; add the created `Transaction`
            // to a List

            // ###Payment
            // A Payment Resource; create one using
            // the above types and intent as `sale` or `authorize`
            var payment = new Payment
            {
                intent = "sale",
                payer = payer,
                transactions = transactionList,
                redirect_urls = redirUrls
            };

            var myResponse = payment.Create(apiContext);

            if (myResponse == null || myResponse.links == null)
            {
                return new PaymentResponse(PaymentStatus.Complete, string.Empty);
            }

            var approvalUrl = myResponse.links.FirstOrDefault(lnk => lnk.rel.Equals("approval_url", StringComparison.OrdinalIgnoreCase));
            if (approvalUrl == null)
                return new PaymentResponse(PaymentStatus.Failed, string.Empty);

            cart.SetPaymentTransaction(myResponse.id);

            return new PaymentResponse(PaymentStatus.Complete, myResponse.id, new {ApprovalUrl = approvalUrl.href});

        }

        public void CompletePayment(string payReference, string payerId)
        {
            var apiContext = ApiContextFactory.Create();
            var payment = new Payment { id = payReference };
            var paymentExecution = new PaymentExecution { payer_id = payerId };


            // Call paypal to complete the payment
            payment.Execute(apiContext, paymentExecution);
        }
    }
}
