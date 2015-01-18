using System.Linq;
using AutoMapper;
using Neemo.ShoppingCart;
using Neemo.Store;

namespace Neemo.Web.Models
{
    public class CartToInvoiceConverter : ITypeConverter<Cart, InvoiceDetailView>
    {
        public InvoiceDetailView Convert(ResolutionContext context)
        {
            var cart = (Cart)context.SourceValue;

            return new InvoiceDetailView
            {
                GrandTotal = cart.CalculateGrandTotal(),
                SubTotal = cart.CalculateSubTotalWithoutTax(),
                Shipping = cart.ShippingCost,
                Tax = cart.CalculateTotalTax().TaxAmount,
                BillingDetailsView = Mapper.Map<PersonalDetails, PersonalDetailsView>(cart.BillingDetails),
                InvoiceLineItems = cart.GetItems().OfType<ProductCartItem>().Select(Mapper.Map<ProductCartItem, InvoiceItemView>).ToList(),
                InvoiceNumber = cart.PaymentTransactionId,
            };
        }
    }
}