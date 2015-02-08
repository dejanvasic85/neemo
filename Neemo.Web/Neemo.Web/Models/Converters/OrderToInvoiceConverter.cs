using System.Linq;
using AutoMapper;
using Neemo.Orders;

namespace Neemo.Web.Models
{
    public class OrderToInvoiceConverter : ITypeConverter<Order, InvoiceDetailView>
    {
        public InvoiceDetailView Convert(ResolutionContext context)
        {
            var order = (Order)context.SourceValue;

            return new InvoiceDetailView
            {
                GrandTotal = order.GetGrandTotal(),
                SubTotal = order.TotalAmount,
                Shipping = order.ShippingTotal,
                Tax = order.TaxTotal,
                BillingDetailsView = Mapper.Map<PersonalDetails, PersonalDetailsView>(order.BillingDetails),
                InvoiceLineItems = order.OrderLineItems.Select(Mapper.Map<OrderLineItem, InvoiceItemView>).ToList(),
                InvoiceNumber = order.InvoiceNumber,
                OrderId = order.OrderId.GetValueOrDefault(),
                PaidWithPayPal = order.PaymentTransactionId.HasValue()
            };
        }
    }
}