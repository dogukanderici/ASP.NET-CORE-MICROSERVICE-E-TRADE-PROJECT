using MultiShop.Dtos.CatalogDtos.ProductImageDtos;
using System.Net;

namespace MultiShop.WebUI.Services.CatalogServices.ProductImageServices
{
    public class ProductImageService : IProductImageService
    {
        private readonly HttpClient _httpClient;

        public ProductImageService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<HttpResponseMessage> CreateDataAsync(CreateProductImageDto createDto)
        {
            var requestMessage = await _httpClient.PostAsJsonAsync<CreateProductImageDto>("productimages", createDto);

            return requestMessage;
        }

        public async Task<HttpResponseMessage> DeleteDataAsync(string id)
        {
            var requestMessage = await _httpClient.DeleteAsync("productimages?id=" + id);

            return requestMessage;
        }

        public async Task<List<ResultProductImageDto>> GetAllDataAsync()
        {
            var response = await _httpClient.GetAsync("productimages");
            var values = await response.Content.ReadFromJsonAsync<List<ResultProductImageDto>>();

            return values.ToList();
        }

        public async Task<GetByIdProductImageDto> GetByProductIdProductImagesAsync(string id)
        {
            var response = await _httpClient.GetAsync("productimages/productimagesbyproductid?id=" + id);
            var values = new GetByIdProductImageDto();

            if (response.StatusCode == HttpStatusCode.OK)
            {
                values = await response.Content.ReadFromJsonAsync<GetByIdProductImageDto>();
            }

            return values;
        }

        public async Task<UpdateProductImageDto> GetDataAsync(string id)
        {
            var response = await _httpClient.GetAsync("productimages/" + id);
            var values = await response.Content.ReadFromJsonAsync<UpdateProductImageDto>();

            return values;
        }

        public async Task<HttpResponseMessage> UpdateDataAsync(UpdateProductImageDto updateDto)
        {
            var requestMessage = await _httpClient.PutAsJsonAsync<UpdateProductImageDto>("productimages", updateDto);

            return requestMessage;
        }
    }
}
