using System;
using System.Collections.Generic;
using System.Linq;

namespace Neemo.ShoppingCart
{
    [Serializable]
    public class Cart
    {
        private readonly string _username;
        private List<ICartItem> _items;
        
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

        public bool DoesNotHaveProduct(int productId)
        {
            return _items.All(p => p.Id != productId);
        }

        public void UpdateProduct(int productId, int qty)
        {
            _items.First(p => p.Id == productId).UpdateQuantity(qty);
        }
    }
}
