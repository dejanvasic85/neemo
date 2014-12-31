using System;

namespace Neemo.ShoppingCart
{
    public class CartException : Exception
    {
        public CartException(string message) :base(message)
        { }
    }
}