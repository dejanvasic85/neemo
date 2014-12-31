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
            cart = new Cart(HttpContext.Current.User.Identity.Name);

            HttpContext.Current.Session[Key] = cart;
            return cart;
        }
    }
}