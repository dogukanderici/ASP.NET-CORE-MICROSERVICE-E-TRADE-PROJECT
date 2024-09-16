using MultiShop.Dtos.CatalogDtos.AboutDtos;
using MultiShop.Dtos.CatalogDtos.ContactDtos;
using System.Net.Http;

namespace MultiShop.WebUI.Services.CatalogServices.ContactServices
{
    public class ContactService : IContactService
    {
        private readonly HttpClient _httpClient;

        public ContactService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<HttpResponseMessage> CreateDataAsync(CreateContactDto createDto)
        {
            var requestMessage = await _httpClient.PostAsJsonAsync<CreateContactDto>("contacts", createDto);

            return requestMessage;
        }

        public async Task<HttpResponseMessage> DeleteDataAsync(string id)
        {
            var requestMessage = await _httpClient.DeleteAsync("contacts?id=" + id);

            return requestMessage;
        }

        public async Task<List<ResultContactDto>> GetAllDataAsync()
        {
            var response = await _httpClient.GetAsync("contacts");
            var values = await response.Content.ReadFromJsonAsync<List<ResultContactDto>>();

            return values.ToList();
        }

        public async Task<ResultContactDto> GetDataAsync(string id)
        {
            var response = await _httpClient.GetAsync("contacts/" + id);
            var values = await response.Content.ReadFromJsonAsync<ResultContactDto>();

            return values;
        }
        public async Task<HttpResponseMessage> UpdateDataAsync(ResultContactDto updateDto)
        {
            throw new NotImplementedException();
        }
    }
}
