using Microsoft.AspNetCore.Mvc;
using NTT.WebApi.Data;
using NTT.WebApi.Data.Services;
using NTT.WebApi.Database;

namespace NTT.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController(IProductService productService) : Controller
    {
        [HttpGet("Products")]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            var products = await productService.GetProducts();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BaseResponseModel>> GetOneProduct(int id)
        {
            var product = await productService.GetOneProduct(id);
            return Ok(new BaseResponseModel { Success = true, Data = product });
        }

        [HttpGet("ProductsAndCats")]
        public async Task<ActionResult<BaseResponseModel>> GetProductsAndCats()
        {
            var products = await productService.GetProductsAndCatsView();
            return Ok(new BaseResponseModel { Success = true , Data = products});
        }
        [HttpPost]
        public async Task<ActionResult<Product>> CreateProduct(Product product)
        {
            await productService.CreateProduct(product);
            return Ok(new BaseResponseModel { Success = true });
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateProduct(int id, Product product)
        {
            await productService.UpdateProduct(product);
            return Ok(new BaseResponseModel { Success = true });
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProduct(int id)
        {
            await productService.DeleteProduct(id);
            return Ok(new BaseResponseModel { Success = true });
        }
    }

}
