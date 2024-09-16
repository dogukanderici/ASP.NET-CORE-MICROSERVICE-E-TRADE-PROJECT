using Microsoft.AspNetCore.Mvc;
using MultiShop.Dtos.CatalogDtos.ProductDtos;
using MultiShop.WebUI.Services.CatalogServices.ProductServices;
using Newtonsoft.Json;

namespace MultiShop.WebUI.ViewComponents.ProductListViewComponents
{
    public class _ProductListComponentPartial : ViewComponent
    {
        private readonly IProductService _productService;

        public _ProductListComponentPartial(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IViewComponentResult> InvokeAsync(string id)
        {
            var value = await _productService.GetProductsWithCategoryByCategoryIdAsync(id);

            if (value != null)
            {
                return View(value);
            }

            return View();
        }
    }
}
