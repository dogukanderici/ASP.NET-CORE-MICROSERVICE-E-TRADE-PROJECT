using Microsoft.AspNetCore.Mvc;
using MultiShop.Dtos.CatalogDtos.ProductImageDtos;
using MultiShop.WebUI.Utilities.FileOperations;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/ProductImage")]
    public class ProductImageController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IFileOperationHelper _fileOperationHelper;

        public ProductImageController(IHttpClientFactory httpClientFactory, IFileOperationHelper fileOperationHelper)
        {
            _httpClientFactory = httpClientFactory;
            _fileOperationHelper = fileOperationHelper;
        }

        [HttpGet]
        public async Task<IActionResult> ProductImageDetail(string id)
        {
            ViewBag.v0 = "Ürün Görselleri İşlemleri";
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Ürün Görselleri";
            ViewBag.v3 = "Ürün Görselleri Listesi";

            var client = _httpClientFactory.CreateClient();

            var checkedResponse = await client.GetAsync("https://localhost:7291/api/productimages/ProductImagesByProductId?id=" + id);

            if (checkedResponse.IsSuccessStatusCode)
            {
                var jsonData = await checkedResponse.Content.ReadAsStringAsync();

                if (jsonData != null)
                {
                    var checkedData = JsonConvert.DeserializeObject<List<UpdateProductImageDto>>(jsonData);

                    return View(checkedData);
                }
            }

            return View();
        }

        [HttpGet]
        [Route("Create")]
        public IActionResult CreateImageProductImage()
        {
            ViewBag.v0 = "Ürün Görselleri İşlemleri";
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Ürün Görselleri";
            ViewBag.v3 = "Ürün Görseli Ekleme";

            return View();
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> CreateImageProductImage(CreateProductImageDto createProductImageDto)
        {
            var client = _httpClientFactory.CreateClient();

            if (createProductImageDto.ImageUrl1 != null)
            {

                var imageUrl = await SetProductImageFile(createProductImageDto.ImageUrl1);

                createProductImageDto.Image1 = imageUrl;
            }

            if (createProductImageDto.ImageUrl2 != null)
            {

                var imageUrl = await SetProductImageFile(createProductImageDto.ImageUrl2);

                createProductImageDto.Image2 = imageUrl;
            }

            if (createProductImageDto.ImageUrl3 != null)
            {

                var imageUrl = await SetProductImageFile(createProductImageDto.ImageUrl3);

                createProductImageDto.Image3 = imageUrl;
            }

            if (createProductImageDto.ImageUrl4 != null)
            {

                var imageUrl = await SetProductImageFile(createProductImageDto.ImageUrl4);

                createProductImageDto.Image4 = imageUrl;
            }

            var jsonData = JsonConvert.SerializeObject(createProductImageDto);

            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var responseMessage = await client.PostAsync("https://localhost:7291/api/productimages", stringContent);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("ProductListWithCategory", "Product", new { area = "Admin" });
            }

            return View();
        }

        [HttpGet]
        [Route("Update/{id}")]
        public async Task<IActionResult> UpdateProductImage(string id)
        {
            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.GetAsync("https://localhost:7291/api/productimages/ProductImagesByProductId?id=" + id);

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();

                var value = JsonConvert.DeserializeObject<UpdateProductImageDto>(jsonData);

                if (value == null)
                {
                    ViewBag.productId = id;
                    return View("CreateImageProductImage");
                }

                return View(value);
            }

            return View();
        }

        [HttpPost]
        [Route("Update/{id}")]
        public async Task<IActionResult> UpdateProductImage(UpdateProductImageDto updateProductImageDto)
        {
            var client = _httpClientFactory.CreateClient();

            if (updateProductImageDto.ImageUrl1 != null)
            {

                var imageUrl = await SetProductImageFile(updateProductImageDto.ImageUrl1);

                updateProductImageDto.Image1 = imageUrl;
            }

            if (updateProductImageDto.ImageUrl2 != null)
            {

                var imageUrl = await SetProductImageFile(updateProductImageDto.ImageUrl2);

                updateProductImageDto.Image2 = imageUrl;
            }

            if (updateProductImageDto.ImageUrl3 != null)
            {

                var imageUrl = await SetProductImageFile(updateProductImageDto.ImageUrl3);

                updateProductImageDto.Image3 = imageUrl;
            }

            if (updateProductImageDto.ImageUrl4 != null)
            {

                var imageUrl = await SetProductImageFile(updateProductImageDto.ImageUrl4);

                updateProductImageDto.Image4 = imageUrl;
            }

            var jsonData = JsonConvert.SerializeObject(updateProductImageDto);

            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var responseMessage = await client.PutAsync("https://localhost:7291/api/productimages", stringContent);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("ProductListWithCategory", "Product", new { area = "Admin" });
            }

            return View();
        }

        [Route("Delete/{id}")]
        public async Task<IActionResult> DeleteProductImage(string id)
        {
            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.DeleteAsync("https://localhost:7291/api/productimages?id=" + id);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "ProductImage", new { area = "Admin" });
            }

            return View();
        }

        private async Task<string> SetProductImageFile(IFormFile image)
        {
            var imageUrl = await _fileOperationHelper.CopyFileToFoler(new FileProperty
            {
                LoadedFile = image,
                FilePath = "/wwwroot/userfiles/"
            });

            return imageUrl;
        }
    }
}
