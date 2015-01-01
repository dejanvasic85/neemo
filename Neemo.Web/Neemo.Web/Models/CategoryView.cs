using System.Collections.Generic;
using System.Linq;

namespace Neemo.Web.Models
{
    public class CategoryView
    {
        public int CategoryId { get; set; }
        public int? ParentId { get; set; }
        public string Title { get; set; }

        public List<CategoryView> GetChildren(CategoryListView list)
        {
            return list.AllCategories.Where(c=> c.ParentId==CategoryId).ToList();
        }
        public bool HasChildren(CategoryListView list)
        {
            return list.AllCategories.Any(c => c.ParentId == CategoryId);
        } 
    }

    public class CategoryListView
    {
        public List<CategoryView> AllCategories { get; set; }

        public List<CategoryView> GetRootCategories()
        {
            return AllCategories.Where(c => c.ParentId == null).ToList();
        } 
    }
}