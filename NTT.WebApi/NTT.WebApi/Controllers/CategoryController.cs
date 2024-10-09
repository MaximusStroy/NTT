using Microsoft.AspNetCore.Mvc;
using NTT.WebApi.Data;
using NTT.WebApi.Data.Services;
using NTT.WebApi.Database;

namespace NTT.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController(ICategoryService categoryService) : Controller
    {
        [HttpGet]
        public async Task<ActionResult<BaseResponseModel>> GetCategories()
        {
            var cats = await categoryService.GetCategories();
            return Ok(new BaseResponseModel { Success = true, Data = cats });
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BaseResponseModel>> GetOneCategory(int id)
        {
            var cats = await categoryService.GetOneCategory(id);
            return Ok(new BaseResponseModel { Success = true, Data = cats });
        }

    }
}
