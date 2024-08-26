using Microsoft.AspNetCore.Mvc;
using MultiShop.Dtos.CatalogDtos.FeatureSliderDtos;
using MultiShop.WebUI.Areas.Admin.Models;
using MultiShop.WebUI.Utilities.FileOperations;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/FeatureSlider")]
    public class FeatureSliderController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IFileOperationHelper _fileOperationHelper;

        public FeatureSliderController(IHttpClientFactory httpClientFactory, IFileOperationHelper fileOperationHelper)
        {
            _httpClientFactory = httpClientFactory;
            _fileOperationHelper = fileOperationHelper;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            ViewBag.v0 = "Öne Çıkan İşlemleri";
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Öne Çıkanlar";
            ViewBag.v3 = "Öne Çıkan Listesi";
            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.GetAsync("https://localhost:7291/api/featureslider");

            var model = new FeatureSliderListViewModel();

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();

                var values = JsonConvert.DeserializeObject<List<ResultFeatureSliderDto>>(jsonData);

                model.ResultFeatureSliderDto = values;

                return View(model);
            }

            return View(model);
        }

        [HttpGet]
        [Route("Create")]
        public IActionResult CreateFeatureSlider()
        {
            ViewBag.v0 = "Öne Çıkan İşlemleri";
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Öne Çıkanlar";
            ViewBag.v3 = "Yeni Öne Çıkan Girişi";

            return View();
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> CreateFeatureSlider(CreateFeatureSliderDto createFeatureSliderDto)
        {
            var client = _httpClientFactory.CreateClient();

            if (createFeatureSliderDto.Image != null)
            {

                var imageUrl = await _fileOperationHelper.CopyFileToFoler(new FileProperty
                {
                    LoadedFile = createFeatureSliderDto.Image,
                    FilePath = "/wwwroot/userfiles/"
                });

                createFeatureSliderDto.ImageUrl = imageUrl;
            }

            var jsonData = JsonConvert.SerializeObject(createFeatureSliderDto);

            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var responseMessage = await client.PostAsync("https://localhost:7291/api/featureslider", stringContent);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "FeatureSlider", new { area = "Admin" });
            }

            return View();
        }

        [HttpGet]
        [Route("Update/{id}")]
        public async Task<IActionResult> UpdateFeatureSlider(string id)
        {
            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.GetAsync("https://localhost:7291/api/featureslider/" + id);

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();

                var value = JsonConvert.DeserializeObject<UpdateFeatureSliderDto>(jsonData);

                return View(value);
            }

            return View();
        }

        [HttpPost]
        [Route("Update/{id}")]
        public async Task<IActionResult> UpdateFeatureSlider(UpdateFeatureSliderDto updateFeatureSliderDto)
        {
            var client = _httpClientFactory.CreateClient();

            if (updateFeatureSliderDto.Image != null)
            {

                var imageUrl = await _fileOperationHelper.CopyFileToFoler(new FileProperty
                {
                    LoadedFile = updateFeatureSliderDto.Image,
                    FilePath = "/wwwroot/userfiles/"
                });

                updateFeatureSliderDto.ImageUrl = imageUrl;
            }

            var jsonData = JsonConvert.SerializeObject(updateFeatureSliderDto);

            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var responseMessage = await client.PutAsync("https://localhost:7291/api/featureslider", stringContent);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "FeatureSlider", new { area = "Admin" });
            }

            return View();
        }

        [Route("Delete/{id}")]
        public async Task<IActionResult> DeleteFeatureSlider(string id)
        {
            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.DeleteAsync("https://localhost:7291/api/featureslider?id=" + id);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "FeatureSlider", new { area = "Admin" });
            }

            return View();
        }
    }
}
