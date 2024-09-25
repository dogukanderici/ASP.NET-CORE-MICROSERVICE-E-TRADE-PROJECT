
namespace SignalRRealTimeApi.Services.SignalRMessageServices
{
    public class SignalRMessageService : ISignalRMessageService
    {
        private readonly HttpClient _httpClient;

        public SignalRMessageService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<int> GetTotalMessageCountByReceiverId()
        {
            var response = await _httpClient.GetAsync("http://localhost:7299/api/usermessagestatistics");
            var value = await response.Content.ReadAsStringAsync();

            return Convert.ToInt32(value);
        }
    }
}
