

namespace MultiShop.WebUI.Services.StatisticsServices.CatalogStatisticsServices
{
    public class CatalogStatisticsService : ICatalogStatisticsService
    {
        private readonly HttpClient _httpClient;

        public CatalogStatisticsService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<long> GetCategoryCount()
        {
            var response = await _httpClient.GetAsync("statistics/getcategorycount");
            var value = await response.Content.ReadFromJsonAsync<long>();

            return value;

        }

        public async Task<string> GetMaxPriceProductName()
        {
            var response = await _httpClient.GetAsync("statistics/getmaxpriceproductname");
            var value = await response.Content.ReadAsStringAsync();

            return value;
        }

        public async Task<string> GetMinPriceProductName()
        {
            var response = await _httpClient.GetAsync("statistics/getminpriceproductname");
            var value = await response.Content.ReadAsStringAsync();

            return value;
        }

        public Task<decimal> GetProductAvgPrice()
        {
            throw new NotImplementedException();
        }

        public async Task<long> GetProductCount()
        {
            var response = await _httpClient.GetAsync("statistics/getproductcount");
            var value = await response.Content.ReadFromJsonAsync<long>();

            return value;
        }

        public async Task<long> GetVendorCount()
        {
            var response = await _httpClient.GetAsync("statistics/getvendorcount");
            var value = await response.Content.ReadFromJsonAsync<long>();

            return value;
        }
    }
}
