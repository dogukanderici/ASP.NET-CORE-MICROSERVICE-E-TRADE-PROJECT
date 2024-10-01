using Microsoft.AspNetCore.Mvc;
using MultiShop.Dtos.CatalogDtos.ProductImageDtos;
using MultiShop.WebUI.Services.CatalogServices.ProductImageServices;
using MultiShop.WebUI.Utilities.FileOperations;
using MultiShop.WebUI.Utilities.ValidationRules.FluentValidation.ProductImageValidation;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/ProductImage")]
    public class ProductImageController : BaseController
    {
        private readonly IProductImageService _productImageService;
        private readonly IFileOperationHelper _fileOperationHelper;

        public ProductImageController(IProductImageService productImageService, IFileOperationHelper fileOperationHelper)
        {
            _productImageService = productImageService;
            _fileOperationHelper = fileOperationHelper;
        }

        [HttpGet]
        public async Task<IActionResult> ProductImageDetail(string id)
        {
            SetViewBagContent("Ürün Görselleri İşlemleri", "Ana Sayfa", "Ürün Görselleri", "Ürün Görselleri Listesi");

            var checkedResponse = await _productImageService.GetByProductIdProductImagesAsync(id);

            if (checkedResponse != null)
            {
                return View(checkedResponse);
            }

            return View();
        }

        [HttpGet]
        [Route("Create")]
        public IActionResult CreateImageProductImage()
        {
            SetViewBagContent("Ürün Görselleri İşlemleri", "Ana Sayfa", "Ürün Görselleri", "Ürün Görseli Ekleme");

            return View();
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> CreateImageProductImage(CreateProductImageDto createProductImageDto)
        {
            var createProductImageValidator = new CreateProductImageValidator();
            var validator = createProductImageValidator.Validate(createProductImageDto);

            if (validator.IsValid)
            {
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

                var responseMessage = await _productImageService.CreateDataAsync(createProductImageDto);

                if (responseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction("ProductListWithCategory", "Product", new { area = "Admin" });
                }
            }

            return View();
        }

        [HttpGet]
        [Route("Update/{id}")]
        public async Task<IActionResult> UpdateProductImage(string id)
        {
            var responseMessage = await _productImageService.GetByProductIdProductImagesAsync(id);

            var model = new UpdateProductImageDto();

            if (responseMessage != null)
            {
                if (responseMessage.ProductImageID == null)
                {
                    ViewBag.productId = id;
                    return View("CreateImageProductImage");
                }

                return View(responseMessage);
            }

            return View();
        }

        [HttpPost]
        [Route("Update/{id}")]
        public async Task<IActionResult> UpdateProductImage(UpdateProductImageDto updateProductImageDto)
        {
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

            var responseMessage = await _productImageService.UpdateDataAsync(updateProductImageDto);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("ProductListWithCategory", "Product", new { area = "Admin" });
            }

            return View();
        }

        [Route("Delete/{id}")]
        public async Task<IActionResult> DeleteProductImage(string id)
        {
            var responseMessage = await _productImageService.DeleteDataAsync(id);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "ProductImage", new { area = "Admin" });
            }

            return RedirectToAction("NotFound404", "Error");
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

        void SetViewBagContent(string mainTitle, string homePageTitle, string title, string subTitle)
        {
            ViewBag.v0 = mainTitle;
            ViewBag.v1 = homePageTitle;
            ViewBag.v2 = title;
            ViewBag.v3 = subTitle;
        }
    }
}
