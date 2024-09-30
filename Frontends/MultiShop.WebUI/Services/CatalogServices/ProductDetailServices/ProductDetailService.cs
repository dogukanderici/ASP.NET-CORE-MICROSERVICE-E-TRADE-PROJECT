using MultiShop.Dtos.CatalogDtos.ProductDetailDtos;
using System.Net;

namespace MultiShop.WebUI.Services.CatalogServices.ProductDetailServices
{
    public class ProductDetailService : IProductDetailService
    {
        private readonly HttpClient _httpClient;

        public ProductDetailService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<HttpResponseMessage> CreateDataAsync(CreateProductDetailDto createDto)
        {
            var requestMessage = await _httpClient.PostAsJsonAsync<CreateProductDetailDto>("productdetails", createDto);

            return requestMessage;
        }

        public async Task<HttpResponseMessage> DeleteDataAsync(string id)
        {
            var requestMessage = await _httpClient.DeleteAsync("productdetails?id=" + id);

            return requestMessage;
        }

        public async Task<List<ResultProductDetailDto>> GetAllDataAsync()
        {
            var response = await _httpClient.GetAsync("productdetails");
            var values = await response.Content.ReadFromJsonAsync<List<ResultProductDetailDto>>();

            return values.ToList();
        }

        public async Task<UpdateProductDetailDto> GetDataAsync(string id)
        {
            var response = await _httpClient.GetAsync("productdetails/" + id);

            UpdateProductDetailDto values = new UpdateProductDetailDto();

            if (response.StatusCode == HttpStatusCode.OK)
            {
                values = await response.Content.ReadFromJsonAsync<UpdateProductDetailDto>();
            }

            return values;
        }

        public async Task<GetByIdProductDetailDto> GetProductDetailsWithProductIdAsync(string id)
        {
            var response = await _httpClient.GetAsync("productdetails/getproductdetailswithproductid?id=" + id);
            var values = await response.Content.ReadFromJsonAsync<GetByIdProductDetailDto>();

            return values;
        }

        public async Task<HttpResponseMessage> UpdateDataAsync(UpdateProductDetailDto updateDto)
        {
            var requestMessage = await _httpClient.PutAsJsonAsync<UpdateProductDetailDto>("productdetails", updateDto);

            return requestMessage;
        }
    }
}
