using AutoMapper;
using Neemo.Orders;

namespace Neemo.Web.Models
{
    public class OrderLineItemToInvoiceItem : ITypeConverter<OrderLineItem, InvoiceItemView>
    {
        public InvoiceItemView Convert(ResolutionContext context)
        {
            var orderItem = (OrderLineItem) context.SourceValue;

            return new InvoiceItemView
            {
                Title = orderItem.ProductName,
                Quantity = orderItem.Quantity,
                ItemSubTotalWithoutTax = orderItem.UnitPrice
            };
        }
    }
}