﻿using Microsoft.AspNetCore.Mvc;
using MultiShop.Dtos.CatalogDtos.CategoryDtos;
using MultiShop.WebUI.Utilities.AuthTokenOperations;
using Newtonsoft.Json;

namespace MultiShop.WebUI.ViewComponents.UILayoutViewComponents
{
    public class _NavbarUILayoutComponentPartial : ViewComponent
    {
        private IHttpClientFactory _httpClientFactory;

        public _NavbarUILayoutComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();

            // API erişimi için token alınır.
            AuthTokenOperation authTokenOperation = new AuthTokenOperation();
            await authTokenOperation.GetAuthTokenForAPI(_httpClientFactory, client);

            var responseMessage = await client.GetAsync("https://localhost:7291/api/categories");

            if (responseMessage.IsSuccessStatusCode)
            {
                // Gelen veriyi string formatta okur.
                var jsonData = await responseMessage.Content.ReadAsStringAsync();

                // Json formatında gelen veri metin tipine dönüştürülür.
                var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);

                return View(values);
            }

            return View();
        }
    }
}
