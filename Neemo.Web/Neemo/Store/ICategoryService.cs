using System.Collections.Generic;

namespace Neemo.Store
{
    public interface ICategoryService
    {
        List<Category> GetAllCategories();

        Category GetCategory(int categoryId);
    }

    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public List<Category> GetAllCategories()
        {
            return _categoryRepository.GetAllCategories();
        }

        public Category GetCategory(int categoryId)
        {
            return _categoryRepository.GetCategory(categoryId);
        }
    }
}