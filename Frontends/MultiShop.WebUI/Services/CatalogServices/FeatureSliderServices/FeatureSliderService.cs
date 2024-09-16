using MultiShop.Dtos.CatalogDtos.FeatureSliderDtos;

namespace MultiShop.WebUI.Services.CatalogServices.FeatureSliderServices
{
    public class FeatureSliderService : IFeatureSliderService
    {
        private readonly HttpClient _httpClient;

        public FeatureSliderService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<HttpResponseMessage> CreateDataAsync(CreateFeatureSliderDto createDto)
        {
            var requestResponse = await _httpClient.PostAsJsonAsync<CreateFeatureSliderDto>("featuresliders", createDto);

            return requestResponse;
        }

        public async Task<HttpResponseMessage> DeleteDataAsync(string id)
        {
            var requestResponse = await _httpClient.DeleteAsync("featuresliders?id=" + id);

            return requestResponse;
        }

        public async Task<List<ResultFeatureSliderDto>> GetAllDataAsync()
        {
            var response = await _httpClient.GetAsync("featuresliders");
            var values = await response.Content.ReadFromJsonAsync<List<ResultFeatureSliderDto>>();

            return values.ToList();
        }

        public async Task<UpdateFeatureSliderDto> GetDataAsync(string id)
        {
            var response = await _httpClient.GetAsync("featuresliders/" + id);
            var values = await response.Content.ReadFromJsonAsync<UpdateFeatureSliderDto>();

            return values;
        }

        public async Task<HttpResponseMessage> UpdateDataAsync(UpdateFeatureSliderDto updateDto)
        {
            var requestMessage = await _httpClient.PutAsJsonAsync<UpdateFeatureSliderDto>("featuresliders", updateDto);

            return requestMessage;
        }

        public Task ChangeFeatureSliderStatusAsync(string id, bool status)
        {
            throw new NotImplementedException();
        }
    }
}
