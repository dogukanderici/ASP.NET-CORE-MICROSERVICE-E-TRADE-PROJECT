using MultiShop.Dtos.CatalogDtos.ServiceStandardDtos;

namespace MultiShop.WebUI.Services.CatalogServices.ServiceStandardServices
{
    public class ServiceStandardService : IServiceStandardService
    {
        private readonly HttpClient _httpClient;

        public ServiceStandardService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<HttpResponseMessage> CreateDataAsync(CreateServiceStandardDto createDto)
        {
            var requestResponse = await _httpClient.PostAsJsonAsync<CreateServiceStandardDto>("servicestandards", createDto);

            return requestResponse;

        }

        public async Task<HttpResponseMessage> DeleteDataAsync(string id)
        {
            var requestResponse = await _httpClient.DeleteAsync("servicestandards?id=" + id);

            return requestResponse;
        }

        public async Task<List<ResultServiceStandardDto>> GetAllDataAsync()
        {
            var response = await _httpClient.GetAsync("servicestandards");

            var values = await response.Content.ReadFromJsonAsync<List<ResultServiceStandardDto>>();

            return values.ToList();
        }

        public async Task<UpdateServiceStandardDto> GetDataAsync(string id)
        {
            var response = await _httpClient.GetAsync("servicestandards/" + id);

            var values = await response.Content.ReadFromJsonAsync<UpdateServiceStandardDto>();

            return values;
        }

        public async Task<HttpResponseMessage> UpdateDataAsync(UpdateServiceStandardDto updateDto)
        {
            var requestResponse = await _httpClient.PutAsJsonAsync<UpdateServiceStandardDto>("servicestandards", updateDto);

            return requestResponse;
        }
    }
}
