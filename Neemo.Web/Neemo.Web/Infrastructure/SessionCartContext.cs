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

            // Create new with an Ip Address
            cart = new Cart(HttpContext.Current.Request.UserHostAddress, 
                HttpContext.Current.User.Identity.Name);

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

        public void Clear()
        {
            HttpContext.Current.Session[Key] = null;
        }

        public void SetUser(string email)
        {
            Current().SetUser(email);
        }
    }
}