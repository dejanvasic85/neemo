using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Dapper;
using Neemo.Store;

namespace Neemo.CarParts.EntityFramework
{
    public class CategoryRepository : ICategoryRepository
    {
        public List<Category> GetAllCategories()
        {
            using (var context = DbContextFactory.CreateConnection())
            {
                return context.Query<Category>("SELECT * FROM vw_Category").ToList();
            }
        }

        public Category GetCategory(int categoryId)
        {
            return GetAllCategories().FirstOrDefault(c => c.CategoryId == categoryId);
        }
    }
}