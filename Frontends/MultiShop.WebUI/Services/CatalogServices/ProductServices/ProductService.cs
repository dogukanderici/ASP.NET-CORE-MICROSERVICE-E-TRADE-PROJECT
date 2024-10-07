using MultiShop.Dtos.CatalogDtos.ProductDtos;
using MultiShop.WebUI.Services.CatalogServices.GenericServices;

namespace MultiShop.WebUI.Services.CatalogServices.ProductServices
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _httpClient;

        public ProductService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<HttpResponseMessage> CreateDataAsync(CreateProductDto createDto)
        {
            var requestResponse = await _httpClient.PostAsJsonAsync<CreateProductDto>("products", createDto);

            return requestResponse;
        }

        public async Task<HttpResponseMessage> DeleteDataAsync(string id)
        {
            var requestResponse = await _httpClient.DeleteAsync("products?id=" + id);

            return requestResponse;
        }

        public async Task<List<ResultProductDto>> GetAllDataAsync()
        {
            var response = await _httpClient.GetAsync("products");
            var values = await response.Content.ReadFromJsonAsync<List<ResultProductDto>>();

            return values.ToList();
        }

        public async Task<UpdateProductDto> GetDataAsync(string id)
        {
            var response = await _httpClient.GetAsync("products/" + id);
            var value = await response.Content.ReadFromJsonAsync<UpdateProductDto>();

            return value;
        }

        public async Task<int> GetProductCountWithCategoryId(string id)
        {
            var response = await _httpClient.GetAsync("products/getproductcountwithcategoryid/" + id);
            var value = await response.Content.ReadAsStringAsync();

            return int.Parse(value);
        }

        public async Task<List<ResultProductWithCategoryDto>> GetProductsWithCategoryAsync()
        {
            var response = await _httpClient.GetAsync("products/ProductListWithCategory");
            var values = await response.Content.ReadFromJsonAsync<List<ResultProductWithCategoryDto>>();

            return values.ToList();
        }

        public async Task<List<ResultProductWithCategoryDto>> GetProductsWithCategoryByCategoryIdAsync(string id)
        {
            var response = await _httpClient.GetAsync("products/GetProductsWithCategoryByCategoryIdAsync?id=" + id);
            var values = await response.Content.ReadFromJsonAsync<List<ResultProductWithCategoryDto>>();

            return values.ToList();
        }

        public async Task<HttpResponseMessage> UpdateDataAsync(UpdateProductDto updateDto)
        {
            var requestResponse = await _httpClient.PutAsJsonAsync<UpdateProductDto>("products", updateDto);

            return requestResponse;
        }
    }
}
