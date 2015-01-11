namespace Neemo.Web.Infrastructure
{
    using AutoMapper;
    using Store;
    using System.Linq;
    using System.Web.Mvc;
    using Neemo.ShoppingCart;
    using Microsoft.Practices.Unity;

    public class MagentoController : Controller
    {
        [Dependency]
        public ICategoryService CategoryService { get; set; }

        [Dependency]
        public ICartContext CartContext { get; set; }
        
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var categories = CategoryService.GetAllCategories()
                .Select(Mapper.Map<Store.Category, Models.CategoryView>)
                .ToList();

            ViewBag.Categories = new Models.CategoryListView{AllCategories = categories};

            if (CartContext.HasItemsInCart() && Request.IsAuthenticated)
            {
                ViewBag.CheckoutUrl = Url.Checkout();
            }
            else if (CartContext.HasItemsInCart() && !Request.IsAuthenticated)
            {
                ViewBag.CheckoutUrl = Url.Login();
            }
            else if (!CartContext.HasItemsInCart())
            {
                ViewBag.CheckoutUrl = Url.MyCart();
            }
        }
    }
}