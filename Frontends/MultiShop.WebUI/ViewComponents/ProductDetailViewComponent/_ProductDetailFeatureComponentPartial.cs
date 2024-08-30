using Microsoft.AspNetCore.Mvc;
using MultiShop.Dtos.CatalogDtos.ProductDtos;
using MultiShop.WebUI.Utilities.FileOperations;
using Newtonsoft.Json;

namespace MultiShop.WebUI.ViewComponents.ProductDetailViewComponent
{
    public class _ProductDetailFeatureComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _ProductDetailFeatureComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(string id)
        {
            var client = _httpClientFactory.CreateClient();

            var checkedResponse = await client.GetAsync("https://localhost:7291/api/products/" + id);

            if (checkedResponse.IsSuccessStatusCode)
            {
                var jsonData = await checkedResponse.Content.ReadAsStringAsync();

                if (jsonData != null)
                {
                    var checkedData = JsonConvert.DeserializeObject<UpdateProductDto>(jsonData);

                    return View(checkedData);
                }
            }

            return View();
        }
    }
}
