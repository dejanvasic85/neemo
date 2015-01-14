namespace Neemo.Web.Infrastructure
{
    using System.Web;
    using ShoppingCart;

    public class SessionCartContext : ICartContext
    {
        private const string Key = "cartContext";

        public Cart Current()
        {
            var cart = HttpContext.Current.Session[Key] as Cart;

            if (cart != null)
                return cart;

            // Create new
            cart = new Cart();

            HttpContext.Current.Session[Key] = cart;
            return cart;
        }

        public bool HasItemsInCart()
        {
            return Current().GetItems().Length > 0;
        }

        public bool CheckoutAsGuest
        {
            get
            {
                var isGuest = HttpContext.Current.Session["guest"];
                if (isGuest == null)
                {
                    return false;
                }
                return (bool) isGuest;
            }
            set { HttpContext.Current.Session["guest"] = value; }
        }
    }
}