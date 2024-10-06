using MultiShop.Dtos.OrderDtos.OrderDetailDtos;

namespace MultiShop.WebUI.Services.OrderServices.OrderOrderDetailService
{
    public class OrderDetailService : IOrderDetailService
    {
        private readonly HttpClient _httpClient;

        public OrderDetailService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateOrderDetail(List<CreateOrderDetailDto> createOrderDetailDto)
        {
            await _httpClient.PostAsJsonAsync<List<CreateOrderDetailDto>>("orderdetails", createOrderDetailDto);
        }
    }
}
