﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Neemo.ShoppingCart
{
    [Serializable]
    public class Cart
    {
        private readonly string _username;
        private readonly List<ICartItem> _items;
        
        public Cart(string username)
        {
            _username = username;
            _items = new List<ICartItem>();
        }

        public void AddItem(ICartItem cartItem)
        {
            this._items.Add(cartItem);
        }

        public decimal CalculateSubTotal()
        {
            return this._items.Sum(i => i.CalculatePrice());
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

        public int? GetTotalQuantityForItem(int id)
        {
            return _items.Sum(i => i.Quantity);
        }

        public void UpdateQuantity(string lineItemId, int quantity)
        {
            var item = _items.FirstOrDefault(i => i.LineItemId == lineItemId);
            if (item == null)
                return;
            item.UpdateQuantity(quantity);
        }
    }
}
