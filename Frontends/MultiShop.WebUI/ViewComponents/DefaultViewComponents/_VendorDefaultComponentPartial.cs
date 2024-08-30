using Microsoft.AspNetCore.Mvc;
using MultiShop.Dtos.CatalogDtos.VendorDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUI.ViewComponents.DefaultViewComponents
{
    public class _VendorDefaultComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _VendorDefaultComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();

            var reponseMessage = await client.GetAsync("https://localhost:7291/api/vendors");

            if (reponseMessage.IsSuccessStatusCode)
            {
                var values = await reponseMessage.Content.ReadAsStringAsync();

                var jsonData = JsonConvert.DeserializeObject<List<ResultVendorDto>>(values);

                return View(jsonData);
            }

            return View();
        }
    }
}
