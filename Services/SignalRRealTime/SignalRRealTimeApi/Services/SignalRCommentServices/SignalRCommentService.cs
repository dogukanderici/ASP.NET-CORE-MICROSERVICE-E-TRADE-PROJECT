
namespace SignalRRealTimeApi.Services.SignalRCommentServices
{
    public class SignalRCommentService : ISignalRCommentService
    {
        private readonly HttpClient _httpClient;

        public SignalRCommentService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<int> GetTotalCommentCount()
        {
            var response = await _httpClient.GetAsync("http://localhost:7296/api/commentstatistics");
            var value = await response.Content.ReadAsStringAsync();

            return int.Parse(value);
        }
    }
}
