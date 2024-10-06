using MultiShop.Dtos.OrderDtos.OrderingDtos;
using System.Net;

namespace MultiShop.WebUI.Services.OrderServices.OrderOrderingServices
{
    public class OrderOrderingService : IOrderOrderingService
    {
        private readonly HttpClient _httpClient;

        public OrderOrderingService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<ResultOrderingByUserIdDto>> GetOrderingByUserId(string userId)
        {
            var response = await _httpClient.GetAsync("orderings/getorderingbyuserid?userid=" + userId);
            var values = await response.Content.ReadFromJsonAsync<List<ResultOrderingByUserIdDto>>();

            return values;
        }

        public async Task CreateOrdering(CreateOrderingDto createOrderingDto)
        {
            await _httpClient.PostAsJsonAsync<CreateOrderingDto>("orderings", createOrderingDto);
        }
    }
}
