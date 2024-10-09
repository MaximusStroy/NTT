using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using Newtonsoft.Json;
using NTT.WebApi.Data;
using NTT.WebApi.Data.Repositories;
using NTT.WebApi.Database;
using NTT.WebClient.Models;
using System.Diagnostics;

namespace NTT.WebClient.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly ApiClient apiClient;
        private int _Id { get; set; } = 0;
        public List<VProdCat> Products { get; set; }

        public HomeController(ILogger<HomeController> logger, ApiClient _apiClient)
        {
            _logger = logger;
            apiClient = _apiClient;
        }

        public async Task<IActionResult> Index()
        {
            await LoadList();
            return View(Products);
        }
        [HttpGet]
        public async Task<IActionResult> Update(int? id)
        {
            if (id == null) return NotFound();
            _Id = (int)id;
            var res = await apiClient.GetFromJsonAsync<BaseResponseModel>($"/api/Product/{id}");
            var model = new Product();
            model = JsonConvert.DeserializeObject<Product>(res.Data.ToString());
            res = await apiClient.GetFromJsonAsync<BaseResponseModel>($"/api/Category");
            var catsRes = JsonConvert.DeserializeObject<List<Category>>(res.Data.ToString());
            ViewData["Cats"] = new SelectList(catsRes, "Id", "Title");
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Update(Product model)
        {
            //if (model.Id == null) return NotFound();
            var res = await apiClient.PutAsync<BaseResponseModel, Product>($"/api/Product/{model.Id}", model);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var res = await apiClient.GetFromJsonAsync<BaseResponseModel>($"/api/Category");
            var catsRes = JsonConvert.DeserializeObject<List<Category>>(res.Data.ToString());
            ViewData["Cats"] = new SelectList(catsRes, "Id", "Title");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Product model)
        {
            var res = await apiClient.PostAsync<BaseResponseModel, Product>("/api/Product", model);

            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var res = await apiClient.DeleteAsync<BaseResponseModel>($"/api/Product/{id}");

            await LoadList();
            return RedirectToAction("Index");
        }

        private async Task LoadList()
        {
            var res = await apiClient.GetFromJsonAsync<BaseResponseModel>("/api/Product/ProductsAndCats");
            if (res != null)
            {
                this.Products = JsonConvert.DeserializeObject<List<VProdCat>>(res.Data.ToString());
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
