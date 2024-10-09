using Microsoft.EntityFrameworkCore;
using NTT.WebApi.Database;

namespace NTT.WebApi.Data.Repositories
{
    public interface ICategoryRepository
    {
        Task<List<Category>> GetCategories();

        Task<Category> GetOneCategory(int id);
    }

    public class CategoryRepository(NttDbContext dbContext) : ICategoryRepository
    {
        public Task<List<Category>> GetCategories()
        {
            return dbContext.Categories.ToListAsync();
        }

        public Task<Category> GetOneCategory(int id)
        {
            return dbContext.Categories.FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
