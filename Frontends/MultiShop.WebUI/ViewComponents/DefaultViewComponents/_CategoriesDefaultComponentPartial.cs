using Microsoft.AspNetCore.Mvc;
using MultiShop.Dtos.CatalogDtos.CategoryDtos;
using MultiShop.WebUI.Models;
using MultiShop.WebUI.Services.CatalogServices.CategoryServices;
using MultiShop.WebUI.Services.CatalogServices.ProductServices;
using MultiShop.WebUI.Utilities.AuthTokenOperations;
using Newtonsoft.Json;

namespace MultiShop.WebUI.ViewComponents.DefaultViewComponents
{
    public class _CategoriesDefaultComponentPartial : ViewComponent
    {
        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;

        public _CategoriesDefaultComponentPartial(ICategoryService categoryService, IProductService productService)
        {
            _categoryService = categoryService;
            _productService = productService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var requestMessage = await _categoryService.GetAllDataAsync();

            var model = new List<FeatureCategoriesListViewModel>();

            foreach (var item in requestMessage)
            {
                var productCount = await _productService.GetProductCountWithCategoryId(item.CategoryID);

                model.Add(new FeatureCategoriesListViewModel
                {
                    FeatureCategoriesList = new FeatureCategoriesList
                    {
                        Categories = item,
                        ProductCount = productCount
                    }
                });
            }

            if (requestMessage != null)
            {
                return View(model);
            }

            return View();
        }
    }
}
