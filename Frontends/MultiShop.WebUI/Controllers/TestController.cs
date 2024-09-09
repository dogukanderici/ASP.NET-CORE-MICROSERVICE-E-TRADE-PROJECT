using Microsoft.AspNetCore.Mvc;
using MultiShop.Dtos.CatalogDtos.CategoryDtos;
using MultiShop.WebUI.Services.CatalogServices.CategoryServices;
using MultiShop.WebUI.Utilities.AuthTokenOperations;
using MultiShop.WebUI.Utilities.FileOperations;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;

namespace MultiShop.WebUI.Controllers
{
    public class TestController : Controller
    {
        private IHttpClientFactory _httpClientFactory;
        private readonly ICategoryService _categoryService;

        public TestController(IHttpClientFactory httpClientFactory, ICategoryService categoryService)
        {
            _httpClientFactory = httpClientFactory;
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index()
        {

            var client = _httpClientFactory.CreateClient();

            AuthTokenOperation authTokenOperation = new AuthTokenOperation();

            await authTokenOperation.GetAuthTokenForAPI(_httpClientFactory, client);

            var responseMessage = await client.GetAsync("http://localhost:7291/api/categories");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();

                var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);

                return View(values);
            }

            return View();
        }

        public async Task<IActionResult> Deneme2()
        {
            var values = await _categoryService.GetAllDataAsync();

            return View(values);
        }
    }
}
