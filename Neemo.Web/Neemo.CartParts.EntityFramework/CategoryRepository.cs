using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Neemo.Store;

namespace Neemo.CarParts.EntityFramework
{
    public class CategoryRepository : ICategoryRepository
    {
        public List<Category> GetAllCategories()
        {
            using (var context = DbContextFactory.Create())
            {
                return context.Categories.Where(c => c.Active == true).Select(Mapper.Map<Models.Category, Store.Category>).ToList();
            }
        }

        public Category GetCategory(int categoryId)
        {
            using (var context = DbContextFactory.Create())
            {
                var category = context.Categories.Where(c => c.Active == true).Single(p => p.CategoryID == categoryId);

                return Mapper.Map<Models.Category, Store.Category>(category);
            }
        }
    }
}