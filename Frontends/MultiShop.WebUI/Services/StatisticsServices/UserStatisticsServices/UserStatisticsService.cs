
namespace MultiShop.WebUI.Services.StatisticsServices.UserStatisticsServices
{
    public class UserStatisticsService : IUserStatisticsService
    {
        private readonly HttpClient _httpClient;

        public UserStatisticsService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<int> GetUserCount()
        {
            var response = await _httpClient.GetAsync("api/statistics");
            var value = await response.Content.ReadAsStringAsync();

            return Convert.ToInt32(value);
        }
    }
}
