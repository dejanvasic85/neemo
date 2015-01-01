namespace Neemo.Web.Infrastructure
{
    using AutoMapper;
    using Store;
    using System.Linq;
    using System.Web.Mvc;
    using Microsoft.Practices.Unity;

    public class MagentoController : Controller
    {
        [Dependency]
        public ICategoryService CategoryService { get; set; }
        
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var categories = CategoryService.GetAllCategories()
                .Select(Mapper.Map<Store.Category, Models.CategoryView>)
                .ToList();

            ViewBag.Categories = new Models.CategoryListView{AllCategories = categories};
        }
    }
}