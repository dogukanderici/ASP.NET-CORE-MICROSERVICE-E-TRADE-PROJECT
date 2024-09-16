using Microsoft.AspNetCore.Mvc;
using MultiShop.Dtos.CatalogDtos.ProductDtos;
using MultiShop.WebUI.Services.CatalogServices.ProductServices;
using MultiShop.WebUI.Utilities.FileOperations;
using Newtonsoft.Json;

namespace MultiShop.WebUI.ViewComponents.ProductDetailViewComponent
{
    public class _ProductDetailFeatureComponentPartial : ViewComponent
    {

        private readonly IProductService _productService;

        public _ProductDetailFeatureComponentPartial(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IViewComponentResult> InvokeAsync(string id)
        {
            var requestMessage = await _productService.GetDataAsync(id);

            if (requestMessage != null)
            {
                return View(requestMessage);
            }

            return View();
        }
    }
}
