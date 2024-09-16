using MultiShop.Dtos.CatalogDtos.OfferDiscountDtos;

namespace MultiShop.WebUI.Services.CatalogServices.OfferDiscountServices
{
    public class OfferDiscountService : IOfferDiscountService
    {
        private readonly HttpClient _httpClient;

        public OfferDiscountService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<HttpResponseMessage> CreateDataAsync(CreateOfferDiscountDto createDto)
        {
            var requestMessage = await _httpClient.PostAsJsonAsync<CreateOfferDiscountDto>("offerdiscounts", createDto);

            return requestMessage;
        }

        public async Task<HttpResponseMessage> DeleteDataAsync(string id)
        {
            var requestMessage = await _httpClient.DeleteAsync("offerdiscounts?id=" + id);

            return requestMessage;
        }

        public async Task<List<ResultOfferDiscountDto>> GetAllDataAsync()
        {
            var response = await _httpClient.GetAsync("offerdiscounts");
            var values = await response.Content.ReadFromJsonAsync<List<ResultOfferDiscountDto>>();

            return values.ToList();
        }

        public async Task<UpdateOfferDiscountDto> GetDataAsync(string id)
        {
            var response = await _httpClient.GetAsync("offerdiscounts/" + id);
            var values = await response.Content.ReadFromJsonAsync<UpdateOfferDiscountDto>();

            return values;
        }

        public async Task<HttpResponseMessage> UpdateDataAsync(UpdateOfferDiscountDto updateDto)
        {
            var requestMessage = await _httpClient.PutAsJsonAsync<UpdateOfferDiscountDto>("offerdiscounts", updateDto);

            return requestMessage;
        }
    }
}
