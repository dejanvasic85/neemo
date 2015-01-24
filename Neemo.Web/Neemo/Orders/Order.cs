using System;
using System.Linq;
using Neemo.ShoppingCart;

namespace Neemo.Orders
{
    public class Order
    {
        public static Order FromShoppingCart(Cart shoppingCart)
        {
            // Create new one from shopping cart, ready for Db
            return new Order
            {
                GUID = Guid.NewGuid(),
                ShippingDetails = shoppingCart.ShippingDetails,
                BillingDetails = shoppingCart.BillingDetails,
                HandlingTotal = 0,
                ShippingTotal = shoppingCart.ShippingCost,
                TaxTotal = shoppingCart.CalculateTotalTax(),
                TotalAmount = shoppingCart.CalculateSubTotalWithoutTax(),
                SourceIpAddress = shoppingCart.SourceIpAddress,
                OrderLineItems = shoppingCart.GetItems().Select(OrderLineItem.FromShoppingCartItem).ToArray(),
                UserName = shoppingCart.UserName,
                CreatedDateTime = DateTime.Now
            };
        }

        public static Order Create(PersonalDetails billingDetails, PersonalDetails shippingDetails, DateTime createdDateTime, Guid guid, decimal handlingTotal, int? orderId, decimal shippingTotal, string sourceIpAddress, decimal taxTotal, decimal totalAmount, string userName, OrderLineItem[] orderLineItems)
        {
            return new Order
            {
                BillingDetails = billingDetails,
                ShippingDetails = shippingDetails,
                CreatedDateTime = createdDateTime,
                GUID = guid,
                HandlingTotal = handlingTotal,
                OrderId = orderId,
                ShippingTotal = shippingTotal,
                SourceIpAddress = sourceIpAddress,
                TaxTotal = taxTotal,
                TotalAmount = totalAmount,
                UserName = userName,
                OrderLineItems = orderLineItems
            };
        }

        public int? OrderId { get; private set; }
        public Guid GUID { get; private set; }
        public PersonalDetails ShippingDetails { get; private set; }
        public PersonalDetails BillingDetails { get; private set; }
        public decimal TotalAmount { get; private set; }
        public decimal TaxTotal { get; private set; }
        public decimal ShippingTotal { get; private set; }
        public decimal HandlingTotal { get; private set; }
        public OrderLineItem[] OrderLineItems { get; private set; }
        public string SourceIpAddress { get; private set; }
        public string UserName { get; set; }
        public DateTime CreatedDateTime { get; private set; }
    }
}
