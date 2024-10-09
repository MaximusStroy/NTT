using NTT.WebApi.Data.Repositories;
using NTT.WebApi.Database;

namespace NTT.WebApi.Data.Services
{

    public interface IProductService
    {
        Task<List<Product>> GetProducts();
        Task<Product> GetOneProduct(int id);
        Task<List<VProdCat>> GetProductsAndCatsView();
        Task<Product> CreateProduct(Product product);
        Task UpdateProduct(Product product);
        Task DeleteProduct(int id);
    }
    public class ProductService(IProductRepository productRepository) : IProductService
    {
        public async Task<Product> CreateProduct(Product product)
        {
            return await productRepository.CreateProduct(product);
        }

        public async Task DeleteProduct(int id)
        {
            await productRepository.DeleteProduct(id);
        }

        public async Task<Product> GetOneProduct(int id)
        {
            return await productRepository.GetOneProduct(id);
        }

        public async Task<List<Product>> GetProducts()
        {
            return await productRepository.GetProducts();
        }

        public async Task<List<VProdCat>> GetProductsAndCatsView()
        {
            return await productRepository.GetProductsAndCatsView();
        }

        public async Task UpdateProduct(Product product)
        {
            await productRepository.UpdateProduct(product);
        }
    }
}
