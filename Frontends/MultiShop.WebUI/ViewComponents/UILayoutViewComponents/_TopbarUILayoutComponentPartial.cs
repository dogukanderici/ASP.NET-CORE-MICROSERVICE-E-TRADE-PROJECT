using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MultiShop.WebUI.Models;
using MultiShop.WebUI.Settings;

namespace MultiShop.WebUI.ViewComponents.UILayoutViewComponents
{
    public class _TopbarUILayoutComponentPartial : ViewComponent
    {
        private readonly ApiKeySettings _apiKeySettings;

        public _TopbarUILayoutComponentPartial(IOptions<ApiKeySettings> apiKeySettings)
        {
            _apiKeySettings = apiKeySettings.Value;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            //var client = new HttpClient();
            //var request = new HttpRequestMessage
            //{
            //    Method = HttpMethod.Get,
            //    RequestUri = new Uri("https://open-weather13.p.rapidapi.com/city/eskisehir/TR"),
            //    Headers =
            //    {
            //        { "x-rapidapi-key", _apiKeySettings.WeatherApiKey },
            //        { "x-rapidapi-host", "open-weather13.p.rapidapi.com" },
            //    },
            //};

            ////string ipAddress = HttpContext.Connection.RemoteIpAddress?.ToString();

            //using (var response = await client.SendAsync(request))
            //{
            //    response.EnsureSuccessStatusCode();
            //    var body = await response.Content.ReadFromJsonAsync<WeatherViewModel>();

            //    var degreeValue = body.main.feels_like;

            //    ViewBag.CityTemp = Math.Round((((degreeValue - 32) * 5) / 9));
            //}

            //var clientUSD = new HttpClient();
            //var requestUSD = new HttpRequestMessage
            //{
            //    Method = HttpMethod.Get,
            //    RequestUri = new Uri("https://real-time-finance-data.p.rapidapi.com/currency-exchange-rate?from_symbol=USD&language=en&to_symbol=TRY"),
            //    Headers =
            //    {
            //        { "x-rapidapi-key", _apiKeySettings.ExchangeApiKey },
            //        { "x-rapidapi-host", "real-time-finance-data.p.rapidapi.com" },
            //    },
            //};

            //using (var responseUSD = await clientUSD.SendAsync(requestUSD))
            //{
            //    responseUSD.EnsureSuccessStatusCode();
            //    var bodyUSD = await responseUSD.Content.ReadFromJsonAsync<ExchangeViewModel>();

            //    ViewBag.USDTRY = Math.Round((bodyUSD.data.exchange_rate), 3);
            //}

            //var clientEUR = new HttpClient();
            //var requestEUR = new HttpRequestMessage
            //{
            //    Method = HttpMethod.Get,
            //    RequestUri = new Uri("https://real-time-finance-data.p.rapidapi.com/currency-exchange-rate?from_symbol=EUR&language=en&to_symbol=TRY"),
            //    Headers =
            //    {
            //        { "x-rapidapi-key", _apiKeySettings.ExchangeApiKey },
            //        { "x-rapidapi-host", "real-time-finance-data.p.rapidapi.com" },
            //    },
            //};

            //using (var responseEUR = await clientEUR.SendAsync(requestEUR))
            //{
            //    responseEUR.EnsureSuccessStatusCode();
            //    var bodyEUR = await responseEUR.Content.ReadFromJsonAsync<ExchangeViewModel>();

            //    ViewBag.EURTRY = Math.Round((bodyEUR.data.exchange_rate), 3);
            //}

            return View();
        }
    }
}
