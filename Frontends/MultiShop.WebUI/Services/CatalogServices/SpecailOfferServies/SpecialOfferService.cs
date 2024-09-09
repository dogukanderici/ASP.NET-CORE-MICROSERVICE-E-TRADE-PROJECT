using MultiShop.Dtos.CatalogDtos.SpecialOfferDtos;

namespace MultiShop.WebUI.Services.CatalogServices.SpecailOfferServies
{
    public class SpecialOfferService : ISpecialOfferService
    {
        private readonly HttpClient _httpClient;

        public SpecialOfferService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<HttpResponseMessage> CreateDataAsync(CreateSpecialOfferDto createDto)
        {
            var requestMessage = await _httpClient.PostAsJsonAsync<CreateSpecialOfferDto>("specialoffers", createDto);

            return requestMessage;
        }

        public async Task<HttpResponseMessage> DeleteDataAsync(string id)
        {
            var requestMessage = await _httpClient.DeleteAsync("specialoffers?id=" + id);

            return requestMessage;
        }

        public async Task<List<ResultSpecialOfferDto>> GetAllDataAsync()
        {
            var response = await _httpClient.GetAsync("specialoffers");
            var values = await response.Content.ReadFromJsonAsync<List<ResultSpecialOfferDto>>();

            return values.ToList();
        }

        public async Task<UpdateSpecialOfferDto> GetDataAsync(string id)
        {
            var response = await _httpClient.GetAsync("specialoffers/" + id);
            var values = await response.Content.ReadFromJsonAsync<UpdateSpecialOfferDto>();

            return values;
        }

        public async Task<HttpResponseMessage> UpdateDataAsync(UpdateSpecialOfferDto updateDto)
        {
            var requestMessage = await _httpClient.PutAsJsonAsync<UpdateSpecialOfferDto>("specialoffers", updateDto);

            return requestMessage;
        }
    }
}
