
namespace MultiShop.WebUI.Services.StatisticsServices.MessageStatisticsServices
{
    public class MessageStatisticsService : IMessageStatisticsService
    {
        private readonly HttpClient _httpClient;

        public MessageStatisticsService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<int> GetTotalMessageCount()
        {
            var response = await _httpClient.GetAsync("usermessages/totalmessagecount");
            var value = await response.Content.ReadAsStringAsync();

            return Convert.ToInt32(value);
        }
    }
}
