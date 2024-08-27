using Microsoft.AspNetCore.Mvc;
using MultiShop.Dtos.CatalogDtos.CategoryDtos;
using MultiShop.WebUI.Areas.Admin.Models;
using MultiShop.WebUI.Utilities.FileOperations;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Category")]
    public class CategoryController : Controller
    {

        private IHttpClientFactory _httpClientFactory;
        private readonly IFileOperationHelper _fileOperationHelper;

        public CategoryController(IHttpClientFactory httpClientFactory, IFileOperationHelper fileOperationHelper)
        {
            _httpClientFactory = httpClientFactory;
            _fileOperationHelper = fileOperationHelper;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            ViewBag.v0 = "Kategori İşlemleri";
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Kategoriler";
            ViewBag.v3 = "Kategori Listesi";

            // Bir client oluşturulur.
            var client = _httpClientFactory.CreateClient();

            // Get tipinde bir istek atmak için GetAsync kullanılır.
            var responseMessage = await client.GetAsync("https://localhost:7291/api/categories");

            var model = new CategoryListViewModel();

            // Servisten 200'lü bir durum kodu dönmesi durumunda kullanılır.
            if (responseMessage.IsSuccessStatusCode)
            {
                // Gelen veriyi string formatta okur.
                var jsonData = await responseMessage.Content.ReadAsStringAsync();

                // Json formatında gelen veri metin tipine dönüştürülür.
                var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);

                model.ResultCategoryDtos = values;
            }

            return View(model);
        }

        [HttpGet]
        [Route("Create")]
        public IActionResult CreateCategory()
        {
            ViewBag.v0 = "Kategori İşlemleri";
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Kategoriler";
            ViewBag.v3 = "Yeni Kategori Girişi";

            return View();
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> CreateCategory(CreateCategoryDto createCategoryDto)
        {
            var client = _httpClientFactory.CreateClient();

            var imageUrl = await _fileOperationHelper.CopyFileToFoler(new FileProperty
            {
                LoadedFile = createCategoryDto.CategoryImage,
                FilePath = "/wwwroot/userfiles/"
            });

            createCategoryDto.CategoryImageUrl = imageUrl;

            var jsonData = JsonConvert.SerializeObject(createCategoryDto);

            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var responseMessage = await client.PostAsync("https://localhost:7291/api/categories", stringContent);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Category", new { area = "Admin" });
            }

            return View();
        }

        [Route("Delete/{id}")]
        public async Task<IActionResult> DeleteCategory(string id)
        {
            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.DeleteAsync("https://localhost:7291/api/categories?id=" + id);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Category", new { area = "Admin" });
            }

            return View();
        }

        [HttpGet]
        [Route("Update/{id}")]
        public async Task<IActionResult> UpdateCategory(string id)
        {
            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.GetAsync("https://localhost:7291/api/categories/" + id);

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();

                var value = JsonConvert.DeserializeObject<UpdateCategoryDto>(jsonData);

                return View(value);
            }

            return View();
        }

        [HttpPost]
        [Route("Update/{id}")]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryDto updateCategoryDto)
        {
            var client = _httpClientFactory.CreateClient();

            if (updateCategoryDto.CategoryImage != null)
            {
                var imageUrl = await _fileOperationHelper.CopyFileToFoler(new FileProperty
                {
                    LoadedFile = updateCategoryDto.CategoryImage,
                    FilePath = "/wwwroot/userfiles/"
                });

                updateCategoryDto.CategoryImageUrl = imageUrl;
            }

            var jsonData = JsonConvert.SerializeObject(updateCategoryDto);

            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var responseMessage = await client.PutAsync("https://localhost:7291/api/categories", stringContent);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Category", new { area = "Admin" });
            }

            return View();
        }


    }
}
