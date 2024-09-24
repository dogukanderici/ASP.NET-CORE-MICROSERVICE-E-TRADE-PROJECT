
namespace MultiShop.WebUI.Services.StatisticsServices.CommentStatisticsServices
{
    public class CommentStatisticsService : ICommentStatisticsService
    {
        private readonly HttpClient _httpClient;

        public CommentStatisticsService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<int> GetActiveCommentCount()
        {
            var response = await _httpClient.GetAsync("comments/activecommentcount");
            var value = await response.Content.ReadAsStringAsync();

            return int.Parse(value);
        }

        public async Task<int> GetPasiveCommentCount()
        {
            var response = await _httpClient.GetAsync("comments/pasivecommentcount");
            var value = await response.Content.ReadAsStringAsync();

            return int.Parse(value);
        }

        public async Task<int> GetTotalCommentCount()
        {
            var response = await _httpClient.GetAsync("comments/totalcommentcount");
            var value = await response.Content.ReadAsStringAsync();

            return int.Parse(value);
        }
    }
}
