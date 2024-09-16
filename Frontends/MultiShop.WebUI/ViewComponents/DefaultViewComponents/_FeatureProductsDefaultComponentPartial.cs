using Microsoft.AspNetCore.Mvc;
using MultiShop.Dtos.CatalogDtos.ProductDtos;
using MultiShop.WebUI.Services.CatalogServices.ProductServices;
using MultiShop.WebUI.Utilities.AuthTokenOperations;
using Newtonsoft.Json;

namespace MultiShop.WebUI.ViewComponents.DefaultViewComponents
{
    public class _FeatureProductsDefaultComponentPartial : ViewComponent
    {
        private readonly IProductService _productService;

        public _FeatureProductsDefaultComponentPartial(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var requestMessage = await _productService.GetAllDataAsync();

            if (requestMessage != null)
            {
                return View(requestMessage);
            }

            return View();
        }
    }
}
