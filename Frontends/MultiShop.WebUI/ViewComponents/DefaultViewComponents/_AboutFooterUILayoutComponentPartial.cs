using Microsoft.AspNetCore.Mvc;
using MultiShop.Dtos.CatalogDtos.AboutDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUI.ViewComponents.DefaultViewComponents
{
    public class _AboutFooterUILayoutComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _AboutFooterUILayoutComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();

            var reponseMessage = await client.GetAsync("https://localhost:7291/api/abouts");

            if (reponseMessage.IsSuccessStatusCode)
            {
                var values = await reponseMessage.Content.ReadAsStringAsync();

                var jsonData = JsonConvert.DeserializeObject<List<ResultAboutDto>>(values);

                return View(jsonData);
            }

            return View();
        }
    }
}
