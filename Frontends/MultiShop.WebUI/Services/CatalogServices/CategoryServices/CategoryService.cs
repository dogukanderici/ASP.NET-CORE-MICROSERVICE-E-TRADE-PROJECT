using MultiShop.Dtos.CatalogDtos.CategoryDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUI.Services.CatalogServices.CategoryServices
{
    public class CategoryService : ICategoryService
    {
        private readonly HttpClient _httpClient;

        public CategoryService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<HttpResponseMessage> CreateDataAsync(CreateCategoryDto createDto)
        {
            var requestResponse = await _httpClient.PostAsJsonAsync<CreateCategoryDto>("categories", createDto);

            return requestResponse;
        }

        public async Task<HttpResponseMessage> DeleteDataAsync(string id)
        {
            var requestResponse = await _httpClient.DeleteAsync("categories?id=" + id);

            return requestResponse;
        }

        public async Task<List<ResultCategoryDto>> GetAllDataAsync()
        {
            var responseMessage = await _httpClient.GetAsync("categories");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);
            return values;
        }

        public async Task<UpdateCategoryDto> GetDataAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync("categories/" + id);
            var values = await responseMessage.Content.ReadFromJsonAsync<UpdateCategoryDto>();

            return values;
        }

        public async Task<HttpResponseMessage> UpdateDataAsync(UpdateCategoryDto updateDto)
        {
            var requestResponse = await _httpClient.PutAsJsonAsync<UpdateCategoryDto>("categories", updateDto);

            return requestResponse;
        }
    }
}