using System.Collections.Generic;
using System.Linq;

namespace Neemo.Web.Models
{
    public class CategoryView
    {
        public int CategoryId { get; set; }
        public int? ParentId { get; set; }
        public string Title { get; set; }

        public CategoryView ParentCategory { get; set; }

        public List<CategoryView> GetChildren(CategoryListView list)
        {
            return list.AllCategories.Where(c => c.ParentId == CategoryId).ToList();
        }
        public bool HasChildren(CategoryListView list)
        {
            return list.AllCategories.Any(c => c.ParentId == CategoryId);
        }

        /// <summary>
        /// Returns a single tree branch where the parent is at 0 index
        /// </summary>
        /// <returns></returns>
        public List<CategoryView> GetOrderedHeirarchy()
        {
            var list = new List<CategoryView>();
            RecurseParent(this, list);
            return list;
        }

        private void RecurseParent(CategoryView category, List<CategoryView> list)
        {
            if (!category.ParentId.HasValue)
            {
                list.Add(category);
                return;
            }

            RecurseParent(category.ParentCategory, list);
            list.Add(category);
        }
    }
}