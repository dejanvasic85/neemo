using System;
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

        public bool DoesNotHaveItem(int id)
        {
            return _items.All(p => p.Id != id);
        }

        public void UpdateItem(int id, int qty)
        {
            _items.First(p => p.Id == id).UpdateQuantity(qty);
        }

        public void RemoveItem(int id)
        {
            _items.RemoveAll(p => p.Id == id);
        }

        public ICartItem[] GetItems()
        {
            return _items.ToArray();
        }

        public int? GetItemQuantity(int id)
        {
            return _items.Sum(i => i.Quantity);
        }
    }
}
