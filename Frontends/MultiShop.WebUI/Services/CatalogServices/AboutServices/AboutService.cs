using MultiShop.Dtos.CatalogDtos.AboutDtos;

namespace MultiShop.WebUI.Services.CatalogServices.AboutServices
{
    public class AboutService : IAboutService
    {
        private readonly HttpClient _httpClient;

        public AboutService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<HttpResponseMessage> CreateDataAsync(CreateAboutDto createDto)
        {
            var requestMessage = await _httpClient.PostAsJsonAsync<CreateAboutDto>("abouts", createDto);

            return requestMessage;
        }

        public async Task<HttpResponseMessage> DeleteDataAsync(string id)
        {
            var requestMessage = await _httpClient.DeleteAsync("abouts?id=" + id);

            return requestMessage;
        }

        public async Task<List<ResultAboutDto>> GetAllDataAsync()
        {
            var response = await _httpClient.GetAsync("abouts");
            var values = await response.Content.ReadFromJsonAsync<List<ResultAboutDto>>();

            return values.ToList();
        }

        public async Task<UpdateAboutDto> GetDataAsync(string id)
        {
            var response = await _httpClient.GetAsync("abouts/" + id);
            var values = await response.Content.ReadFromJsonAsync<UpdateAboutDto>();

            return values;
        }

        public async Task<HttpResponseMessage> UpdateDataAsync(UpdateAboutDto updateDto)
        {
            var requestMessage = await _httpClient.PutAsJsonAsync<UpdateAboutDto>("abouts", updateDto);

            return requestMessage;
        }
    }
}
