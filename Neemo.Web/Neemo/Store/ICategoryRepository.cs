using System.Collections.Generic;

namespace Neemo.Store
{
    public interface ICategoryRepository
    {
        List<Category> GetAllCategories();

        Category GetCategory(int categoryId);
    }
}