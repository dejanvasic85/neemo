using System;
using System.Collections.Generic;
using System.Linq;
using Neemo.Orders;
using Neemo.Shipping;
using Neemo.Tax;

namespace Neemo.ShoppingCart
{
    [Serializable]
    public class Cart
    {
        
        private readonly List<ICartItem> _items;
        public Guid Id { get; private set; }
        public string InvoiceNumber { get; private set; }
        public ShippingCost ShippingCost { get; private set; }
        public PersonalDetails ShippingDetails { get; private set; }
        public PersonalDetails BillingDetails { get; private set; }
        public string PaymentTransactionId { get; private set; }
        public string SourceIpAddress { get; private set; }
        public string UserName { get; private set; }

        public Cart(string sourceIpAddress, string userName)
        {
            _items = new List<ICartItem>();
            SourceIpAddress = sourceIpAddress;
            UserName = userName;

            // Generate a unique shopping cart Id and InvoiceNumber up front
            Id = Guid.NewGuid();
            InvoiceNumber = InvoiceNumberGenerator.Generate(Id);
        }

        public void AddItem(ICartItem cartItem)
        {
            this._items.Add(cartItem);
        }

        public void Checkout()
        {
            // Clear the items
            this._items.Clear();
        }

        public void RemoveItem(string lineItemId)
        {
            _items.RemoveAll(p => p.LineItemId == lineItemId);
        }

        public ICartItem[] GetItems()
        {
            return _items.ToArray();
        }

        /// <summary>
        /// Gets the number of items ordered by excluding the particular line item
        /// </summary>
        public int? GetTotalQuantityForProduct(int id, string excludeLineItemId)
        {
            return _items
                .Where(i=> i.Id == id)
                .Where(i => i.LineItemId != excludeLineItemId)
                .Sum(i => i.Quantity);
        }

        public void UpdateQuantity(string lineItemId, int quantity)
        {
            var item = _items.FirstOrDefault(i => i.LineItemId == lineItemId);
            if (item == null)
                return;
            item.UpdateQuantity(quantity);
        }

        /// <summary>
        /// Sets the shipping cost for the shopping cart
        /// </summary>
        public void SetShippingCost(ShippingCost shipping)
        {
            this.ShippingCost = shipping;
        }

        /// <summary>
        /// Sets the billing details for the shopping cart
        /// </summary>
        public void SetBillingDetails(PersonalDetails billingDetails)
        {
            this.BillingDetails = billingDetails;
        }

        /// <summary>
        /// Sets the shipping details for the shopping cart
        /// </summary>
        /// <param name="shippingDetails"></param>
        public void SetShippingDetails(PersonalDetails shippingDetails)
        {
            this.ShippingDetails = shippingDetails;
        }

        /// <summary>
        /// Returns the total tax for all items (including quantity)
        /// </summary>
        public TaxCost CalculateTotalTax()
        {
            return this._items.Select(t => t.CalculateTotalTax()).TaxCostSum();
        }

        public decimal CalculateSubTotalWithoutTax()
        {
            return this._items.Sum(i => i.CalculateSubTotalWithoutTax());
        }

        /// <summary>
        /// Returns the sub total for the entire order including tax and shipping
        /// </summary>
        public decimal CalculateGrandTotal()
        {
            // Add all the product items (taxes included)
            // Add the shipping
            return _items.Sum(i => i.CalculateSubTotal()) + ShippingCost;
        }

        public void SetPaymentTransaction(string id)
        {
            this.PaymentTransactionId = id;
        }

        public void SetUser(string username)
        {
            this.UserName = username;
        }
    }
}
