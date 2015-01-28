using System;
using Neemo.ShoppingCart;

namespace Neemo.Orders
{
    public class OrderLineItem
    {
        public static OrderLineItem FromShoppingCartItem(ICartItem cartItem)
        {
            // Creates a new one ( ready for the db )
            return new OrderLineItem
            {
                ProductId = cartItem.Id,
                Quantity = cartItem.Quantity,
                TaxTotal = cartItem.CalculateTotalTax(),
                TotalValue = cartItem.CalculateSubTotalWithoutTax(),
                UnitPrice = cartItem.PriceWithoutTax,
                CreatedDateTime = DateTime.Now,
                ProductName = cartItem.Title
            };
        }
        public int? OrderLineItemId { get; private set; }
        public int? OrderId { get; private set; }
        public int ProductId { get; private set; }
        public int Quantity { get; private set; }
        public decimal UnitPrice { get; private set; }
        public decimal TotalValue { get; private set; }
        public decimal TaxTotal { get; private set; }
        public DateTime CreatedDateTime { get; set; }
        public string ProductName { get; set; }
    }
}