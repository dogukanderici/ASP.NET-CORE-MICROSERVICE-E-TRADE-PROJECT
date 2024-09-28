using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MultiShop.RapidApiWebUI.Models;
using MultiShop.RapidApiWebUI.Settings;

namespace MultiShop.RapidApiWebUI.Controllers
{
    public class DefaultController : Controller
    {
        private readonly ApiKeySettings _apiKeySettings;

        public DefaultController(IOptions<ApiKeySettings> apiKeySettings)
        {
            _apiKeySettings = apiKeySettings.Value;
        }

        public async Task<IActionResult> Weather()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://open-weather13.p.rapidapi.com/city/eskisehir/TR"),
                Headers =
                {
                    { "x-rapidapi-key", _apiKeySettings.WeatherApiKey },
                    { "x-rapidapi-host", "open-weather13.p.rapidapi.com" },
                },
            };

            //string ipAddress = HttpContext.Connection.RemoteIpAddress?.ToString();

            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadFromJsonAsync<WeatherViewModel>();

                var degreeValue = body.main.feels_like;

                ViewBag.CityTemp = Math.Round((((degreeValue - 32) * 5) / 9), 2);
            }

            return View();
        }

        public async Task<IActionResult> Exchange()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://real-time-finance-data.p.rapidapi.com/currency-exchange-rate?from_symbol=USD&language=en&to_symbol=TRY"),
                Headers =
                {
                    { "x-rapidapi-key", _apiKeySettings.ExchangeApiKey },
                    { "x-rapidapi-host", "real-time-finance-data.p.rapidapi.com" },
                },
            };

            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadFromJsonAsync<ExchangeViewModel>();

                ViewBag.USDTRY = Math.Round((body.data.exchange_rate), 3);
            }

            return View();
        }

        public async Task<IActionResult> AmazonData()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://real-time-amazon-data.p.rapidapi.com/products-by-category?category_id=12601898031&page=1&country=TR&sort_by=HIGHEST_PRICE&product_condition=ALL&is_prime=false&deals_and_discounts=NONE"),
                Headers =
                {
                    { "x-rapidapi-key", _apiKeySettings.AmazonApiKey },
                    { "x-rapidapi-host", "real-time-amazon-data.p.rapidapi.com" },
                },
            };

            var model = new AmazonDataViewModel();

            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                model = await response.Content.ReadFromJsonAsync<AmazonDataViewModel>();

                return View(model);
            }
        }
    }
}