using System.Collections.Generic;
using System.Linq;

namespace Neemo.Web.Models
{
    public class CategoryListView
    {
        public List<CategoryView> AllCategories { get; set; }

        public List<CategoryView> GetRootCategories()
        {
            return AllCategories.Where(c => c.ParentId == null).ToList();
        } 
    }
}