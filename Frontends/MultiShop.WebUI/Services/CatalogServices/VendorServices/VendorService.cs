using MultiShop.Dtos.CatalogDtos.VendorDtos;

namespace MultiShop.WebUI.Services.CatalogServices.VendorServices
{
    public class VendorService : IVendorService
    {
        private readonly HttpClient _httpClient;

        public VendorService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<HttpResponseMessage> CreateDataAsync(CreateVendorDto createDto)
        {
            var requestMessage = await _httpClient.PostAsJsonAsync<CreateVendorDto>("vendors", createDto);

            return requestMessage;
        }

        public async Task<HttpResponseMessage> DeleteDataAsync(string id)
        {
            var requestMessage = await _httpClient.DeleteAsync("vendors?id=" + id);

            return requestMessage;
        }

        public async Task<List<ResultVendorDto>> GetAllDataAsync()
        {
            var response = await _httpClient.GetAsync("vendors");
            var values = await response.Content.ReadFromJsonAsync<List<ResultVendorDto>>();

            return values.ToList();
        }

        public async Task<UpdateVendorDto> GetDataAsync(string id)
        {
            var response = await _httpClient.GetAsync("vendors/" + id);
            var values = await response.Content.ReadFromJsonAsync<UpdateVendorDto>();

            return values;
        }

        public async Task<HttpResponseMessage> UpdateDataAsync(UpdateVendorDto updateDto)
        {
            var requestMessage = await _httpClient.PutAsJsonAsync<UpdateVendorDto>("vendors", updateDto);

            return requestMessage;
        }
    }
}
