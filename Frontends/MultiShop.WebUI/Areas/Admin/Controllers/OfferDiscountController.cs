using Microsoft.AspNetCore.Mvc;
using MultiShop.Dtos.CatalogDtos.OfferDiscountDtos;
using MultiShop.WebUI.Utilities.FileOperations;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/OfferDiscount")]
    public class OfferDiscountController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IFileOperationHelper _fileOperationHelper;

        public OfferDiscountController(IHttpClientFactory httpClientFactory, IFileOperationHelper fileOperationHelper)
        {
            _httpClientFactory = httpClientFactory;
            _fileOperationHelper = fileOperationHelper;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.GetAsync("https://localhost:7291/api/offerdiscounts");

            if (responseMessage.IsSuccessStatusCode)
            {
                var values = await responseMessage.Content.ReadAsStringAsync();

                var jsonData = JsonConvert.DeserializeObject<List<ResultOfferDiscountDto>>(values);

                return View(jsonData);
            }

            return View();
        }

        [HttpGet]
        [Route("Create")]
        public IActionResult CreateOfferDiscount()
        {
            ViewBag.v0 = "Özel İndirim İşlemleri";
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Özel İndirimler";
            ViewBag.v3 = "Özel İndirim Listesi";

            return View();
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> CreateOfferDiscount(CreateOfferDiscountDto createOfferDiscountDto)
        {
            var client = _httpClientFactory.CreateClient();

            var imageUrl = await _fileOperationHelper.CopyFileToFoler(new FileProperty
            {
                LoadedFile = createOfferDiscountDto.OfferDiscountSubImage,
                FilePath = "/wwwroot/userfiles/"
            });

            createOfferDiscountDto.OfferDiscountSubImageUrl = imageUrl;

            var jsonData = JsonConvert.SerializeObject(createOfferDiscountDto);

            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var responseMessage = await client.PostAsync("https://localhost:7291/api/offerdiscounts", stringContent);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "OfferDiscount", new { area = "Admin" });
            }

            return View();
        }

        [Route("Delete/{id}")]
        public async Task<IActionResult> DeleteOfferDiscount(string id)
        {
            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.DeleteAsync("https://localhost:7291/api/offerdiscounts?id=" + id);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "OfferDiscount", new { area = "Admin" });
            }

            return View();
        }

        [HttpGet]
        [Route("Update/{id}")]
        public async Task<IActionResult> UpdateOfferDiscount(string id)
        {
            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.GetAsync("https://localhost:7291/api/offerdiscounts/" + id);

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();

                var value = JsonConvert.DeserializeObject<UpdateOfferDiscountDto>(jsonData);

                return View(value);
            }

            return View();
        }

        [HttpPost]
        [Route("Update/{id}")]
        public async Task<IActionResult> UpdateOfferDiscount(UpdateOfferDiscountDto updateOfferDiscountDto)
        {
            var client = _httpClientFactory.CreateClient();

            if (updateOfferDiscountDto.OfferDiscountSubImage != null)
            {
                var imageUrl = await _fileOperationHelper.CopyFileToFoler(new FileProperty
                {
                    LoadedFile = updateOfferDiscountDto.OfferDiscountSubImage,
                    FilePath = "/wwwroot/userfiles/"
                });

                updateOfferDiscountDto.OfferDiscountSubImageUrl = imageUrl;
            }

            var jsonData = JsonConvert.SerializeObject(updateOfferDiscountDto);

            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var responseMessage = await client.PutAsync("https://localhost:7291/api/offerdiscounts", stringContent);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "OfferDiscount", new { area = "Admin" });
            }

            return View();
        }
    }
}
