using System.Collections.Generic;
using System.Linq;
using Neemo.Store;

namespace Neemo.DataAccess
{
    public class CategoryRepository : ICategoryRepository
    {
        public List<Category> GetAllCategories()
        {
            return new List<Category>
            {
                new Category{CategoryId = 1, ParentId = null, Title = "Mercedes"},
                new Category{CategoryId = 2, ParentId = 1, Title = "Mercedes - Child 1"},
                new Category{CategoryId = 10, ParentId = 1, Title = "Mercedes - Child 2"},
                new Category{CategoryId = 3, ParentId = 2, Title = "Mercedes - Child 3"},
                new Category{CategoryId = 11, ParentId = 2, Title = "Mercedes - Child 4"},
                new Category{CategoryId = 12, ParentId = 2, Title = "Mercedes - Child 5"},
                new Category{CategoryId = 4, ParentId = null, Title = "Hyundai"},
                new Category{CategoryId = 5, ParentId = null, Title = "Toyota"},
                new Category{CategoryId = 6, ParentId = null, Title = "Chevrolet"},
                new Category{CategoryId = 7, ParentId = null, Title = "Audi"},
                new Category{CategoryId = 8, ParentId = null, Title = "BMW"},
                new Category{CategoryId = 9, ParentId = null, Title = "Lexus"},
            };
        }

        public Category GetCategory(int categoryId)
        {
            var category = GetAllCategories().Single(p => p.CategoryId == categoryId);

            if (category.ParentId.HasValue)
            {
                category.ParentCategory = GetCategory(category.ParentId.Value);
            }

            return category;
        }
    }
}