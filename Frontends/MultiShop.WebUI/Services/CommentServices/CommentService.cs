using MultiShop.Dtos.CommentDtos;

namespace MultiShop.WebUI.Services.CommentServices
{
    public class CommentService : ICommentService
    {
        private readonly HttpClient _httpClient;

        public CommentService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<HttpResponseMessage> CreateDataAsync(CreateCommentDto createDto)
        {
            var requestMessage = await _httpClient.PostAsJsonAsync<CreateCommentDto>("comments", createDto);

            return requestMessage;
        }

        public async Task<HttpResponseMessage> DeleteDataAsync(string id)
        {
            int queryId = Convert.ToInt32(id);

            var requestMessage = await _httpClient.DeleteAsync("comments?id=" + id);

            return requestMessage;
        }

        public async Task<List<ResultCommentDto>> GetAllDataAsync()
        {
            var response = await _httpClient.GetAsync("comments");
            var values = await response.Content.ReadFromJsonAsync<List<ResultCommentDto>>();

            return values.ToList();
        }

        public async Task<List<ResultCommentDto>> GetCommentByProductId(string id)
        {
            var response = await _httpClient.GetAsync("comments/commentbyid?id=" + id);
            var values = await response.Content.ReadFromJsonAsync<List<ResultCommentDto>>();

            return values.ToList();
        }

        public async Task<UpdateCommentDto> GetDataAsync(string id)
        {
            int queryId = Convert.ToInt32(id);

            var response = await _httpClient.GetAsync("comments/" + id);
            var values = await response.Content.ReadFromJsonAsync<UpdateCommentDto>();

            return values;
        }

        public async Task<HttpResponseMessage> UpdateDataAsync(UpdateCommentDto updateDto)
        {
            var requestMessage = await _httpClient.PutAsJsonAsync<UpdateCommentDto>("comments", updateDto);

            return requestMessage;
        }
    }
}
