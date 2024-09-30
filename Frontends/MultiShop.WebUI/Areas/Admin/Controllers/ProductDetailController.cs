using Microsoft.AspNetCore.Mvc;
using MultiShop.Dtos.CatalogDtos.ProductDetailDtos;
using MultiShop.WebUI.Services.CatalogServices.ProductDetailServices;
using MultiShop.WebUI.Utilities.ValidationRules.FluentValidation.ProductDetailValidation;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/ProductDetail")]
    public class ProductDetailController : BaseController
    {
        private readonly IProductDetailService _productDetailService;

        public ProductDetailController(IProductDetailService productDetailService)
        {
            _productDetailService = productDetailService;
        }

        [HttpGet]
        [Route("Create")]
        public IActionResult CreateProductDetail()
        {
            SetViewBagContent("Ürün İşlemleri", "Ana Sayfa", "Ürün Bilgileri", "Ürün Açıklama ve Bilgi Ekleme Sayfası");

            return View();
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> CreateProductDetail(CreateProductDetailDto createProductDetailDto)
        {
            var productDetailValidator = new CreateProductDetailValidator();
            var validator = productDetailValidator.Validate(createProductDetailDto);

            if (validator.IsValid)
            {
                var responseMessage = await _productDetailService.CreateDataAsync(createProductDetailDto);

                if (responseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction("ProductListWithCategory", "Product", new { area = "Admin" });
                }
            }

            return View();
        }

        [HttpGet]
        [Route("Update/{id}")]
        public async Task<IActionResult> UpdateProductDetail(string id)
        {

            SetViewBagContent("Ürün İşlemleri", "Ana Sayfa", "Ürün Bilgileri", "Ürün Açıklama ve Bilgi Güncelleme Sayfası");

            var responseMessage = await _productDetailService.GetProductDetailsWithProductIdAsync(id);

            var model = new GetByIdProductDetailDto();

            if (responseMessage != null)
            {
                if (responseMessage.ProductID != null)
                {
                    model = responseMessage;

                    return View(model);
                }
                else
                {
                    ViewBag.ProductIdForProductDetail = id;
                    return View("CreateProductDetail");
                }
            }

            return View();
        }

        [HttpPost]
        [Route("Update/{id}")]
        public async Task<IActionResult> UpdateProductDetail(UpdateProductDetailDto updateProductDetailDto)
        {
            var updateProductDetailValidator = new UpdateProductDetailValidator();
            var validator = updateProductDetailValidator.Validate(updateProductDetailDto);

            if (validator.IsValid)
            {
                var reponseMessage = await _productDetailService.UpdateDataAsync(updateProductDetailDto);

                if (reponseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction("ProductListWithCategory", "Product", new { area = "Admin" });
                }
            }

            return await UpdateProductDetail(updateProductDetailDto.ProductID);
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
