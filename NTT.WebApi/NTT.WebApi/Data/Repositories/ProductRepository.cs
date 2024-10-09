using Microsoft.EntityFrameworkCore;
using NTT.WebApi.Database;

namespace NTT.WebApi.Data.Repositories
{
    public interface IProductRepository
    {
        Task<List<Product>> GetProducts();
        Task<List<VProdCat>> GetProductsAndCatsView();
        Task<Product> GetOneProduct(int id);
        Task<Product> CreateProduct(Product product);
        Task UpdateProduct(Product product);
        Task DeleteProduct(int id);
    }
    public class ProductRepository(NttDbContext dbContext) : IProductRepository
    {
        public async Task<Product> CreateProduct(Product product)
        {
            await dbContext.Products.AddAsync(product);
            await dbContext.SaveChangesAsync();
            return product;
        }

        public async Task DeleteProduct(int id)
        {
            var model = await dbContext.Products.FirstOrDefaultAsync(p => p.Id == id);
            dbContext.Remove(model);
            await dbContext.SaveChangesAsync();
        }

        public async Task<Product> GetOneProduct(int id)
        {
            return await dbContext.Products.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<List<Product>> GetProducts()
        {
            return await dbContext.Products.ToListAsync();
        }

        public async Task UpdateProduct(Product product)
        {
           // dbContext.Entry(product).State = EntityState.Modified;
            dbContext.Update(product);
           await dbContext.SaveChangesAsync();
        }

        async Task<List<VProdCat>> IProductRepository.GetProductsAndCatsView()
        {
            return await dbContext.VProdCats.ToListAsync();
        }
    }
}
