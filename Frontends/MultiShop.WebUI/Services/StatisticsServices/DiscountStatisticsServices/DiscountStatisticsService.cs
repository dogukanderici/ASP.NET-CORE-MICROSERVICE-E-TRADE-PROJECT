
namespace MultiShop.WebUI.Services.StatisticsServices.DiscountStatisticsServices
{
    public class DiscountStatisticsService : IDiscountStatisticsService
    {
        private readonly HttpClient _httpClient;

        public DiscountStatisticsService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<int> GetDiscountCouponCount()
        {
            var response = await _httpClient.GetAsync("discounts/getdiscountcouponcount");
            var value = await response.Content.ReadAsStringAsync();

            return int.Parse(value);
        }

        public async Task<int> GetDiscountCouponCountRate(string code)
        {
            var response = await _httpClient.GetAsync("discounts/getdiscountcouponcountrate");
            var value = await response.Content.ReadAsStringAsync();

            return int.Parse(value);
        }
    }
}
