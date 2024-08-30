using Microsoft.AspNetCore.Mvc;
using MultiShop.Dtos.CatalogDtos.VendorDtos;
using MultiShop.WebUI.Utilities.FileOperations;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Vendor")]
    public class VendorController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IFileOperationHelper _fileOperationHelper;

        public VendorController(IHttpClientFactory httpClientFactory, IFileOperationHelper fileOperationHelper)
        {
            _httpClientFactory = httpClientFactory;
            _fileOperationHelper = fileOperationHelper;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();

            var reponseMessage = await client.GetAsync("https://localhost:7291/api/vendors");

            if (reponseMessage.IsSuccessStatusCode)
            {
                var values = await reponseMessage.Content.ReadAsStringAsync();

                var jsonData = JsonConvert.DeserializeObject<List<ResultVendorDto>>(values);

                return View(jsonData);
            }

            return View();
        }

        [HttpGet]
        [Route("Create")]
        public IActionResult CreateVendor()
        {
            ViewBag.v0 = "Marka İşlemleri";
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Markalar";
            ViewBag.v3 = "Marka Listesi";

            return View();
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> CreateVendor(CreateVendorDto createVendorDto)
        {
            var client = _httpClientFactory.CreateClient();

            var imageUrl = await _fileOperationHelper.CopyFileToFoler(new FileProperty
            {
                LoadedFile = createVendorDto.VendorImage,
                FilePath = "/wwwroot/userfiles/"
            });

            createVendorDto.VendorImageUrl = imageUrl;

            var jsonData = JsonConvert.SerializeObject(createVendorDto);

            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var responseMessage = await client.PostAsync("https://localhost:7291/api/vendors", stringContent);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Vendor", new { area = "Admin" });
            }

            return View();
        }

        [Route("Delete/{id}")]
        public async Task<IActionResult> DeleteVendor(string id)
        {
            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.DeleteAsync("https://localhost:7291/api/vendors?id=" + id);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Vendor", new { area = "Admin" });
            }

            return View();
        }

        [HttpGet]
        [Route("Update/{id}")]
        public async Task<IActionResult> UpdateVendor(string id)
        {
            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.GetAsync("https://localhost:7291/api/vendors/" + id);

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();

                var value = JsonConvert.DeserializeObject<UpdateVendorDto>(jsonData);

                return View(value);
            }

            return View();
        }

        [HttpPost]
        [Route("Update/{id}")]
        public async Task<IActionResult> UpdateVendor(UpdateVendorDto updateVendorDto)
        {
            var client = _httpClientFactory.CreateClient();

            if (updateVendorDto.VendorImage != null)
            {
                var imageUrl = await _fileOperationHelper.CopyFileToFoler(new FileProperty
                {
                    LoadedFile = updateVendorDto.VendorImage,
                    FilePath = "/wwwroot/userfiles/"
                });

                updateVendorDto.VendorImageUrl = imageUrl;
            }

            var jsonData = JsonConvert.SerializeObject(updateVendorDto);

            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var responseMessage = await client.PutAsync("https://localhost:7291/api/vendors", stringContent);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Vendor", new { area = "Admin" });
            }

            return View();
        }
    }
}
