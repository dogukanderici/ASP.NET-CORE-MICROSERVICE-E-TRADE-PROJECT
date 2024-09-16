using Microsoft.AspNetCore.Mvc;
using MultiShop.Dtos.CatalogDtos.ProductImageDtos;
using MultiShop.WebUI.Services.CatalogServices.ProductImageServices;
using Newtonsoft.Json;

namespace MultiShop.WebUI.ViewComponents.ProductDetailViewComponent
{
    public class _ProductDetailImageSliderComponentPartial : ViewComponent
    {
        private readonly IProductImageService _productImageService;

        public _ProductDetailImageSliderComponentPartial(IProductImageService productImageService)
        {
            _productImageService = productImageService;
        }

        public async Task<IViewComponentResult> InvokeAsync(string id)
        {

            var requestMessage = await _productImageService.GetByProductIdProductImagesAsync(id);

            if (requestMessage != null)
            {
                return View(requestMessage);
            }

            return View();
        }
    }
}
