using Microsoft.AspNetCore.Mvc;
using MultiShop.Dtos.CatalogDtos.ProductDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUI.ViewComponents.ProductListViewComponents
{
    public class _ProductListComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _ProductListComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(string id)
        {

            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.GetAsync("https://localhost:7291/api/products/GetProductsWithCategoryByCategoryIdAsync?id=" + id);

            if (responseMessage.IsSuccessStatusCode)
            {
                var values = await responseMessage.Content.ReadAsStringAsync();

                var jsonData = JsonConvert.DeserializeObject<List<ResultProductWithCategoryDto>>(values);

                return View(jsonData);
            }

            return View();
        }
    }
}
