using Microsoft.AspNetCore.Mvc;
using MultiShop.Dtos.CatalogDtos.ProductImageDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUI.ViewComponents.ProductDetailViewComponent
{
    public class _ProductDetailImageSliderComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _ProductDetailImageSliderComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(string id)
        {
            var client = _httpClientFactory.CreateClient();

            var checkedResponse = await client.GetAsync("https://localhost:7291/api/productimages/ProductImagesByProductId?id=" + id);

            if (checkedResponse.IsSuccessStatusCode)
            {
                var jsonData = await checkedResponse.Content.ReadAsStringAsync();

                if (jsonData != null)
                {
                    var checkedData = JsonConvert.DeserializeObject<GetByIdProductImageDto>(jsonData);

                    return View(checkedData);
                }
            }

            return View();
        }
    }
}
