using NTT.WebApi.Data.Repositories;
using NTT.WebApi.Database;

namespace NTT.WebApi.Data.Services
{
    public interface ICategoryService
    {
        Task<List<Category>> GetCategories();
        Task<Category> GetOneCategory(int id);
    }

    public class CategoryService(ICategoryRepository categoryRepository) : ICategoryService
    {
        public Task<List<Category>> GetCategories()
        {
            return categoryRepository.GetCategories();
        }

        public Task<Category> GetOneCategory(int id)
        {
            return categoryRepository.GetOneCategory(id);
        }
    }
}
