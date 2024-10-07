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

        public async Task<List<ResultOrderDetailDto>> GetOrderDetail(Guid orderingId)
        {
            var response = await _httpClient.GetAsync("orderdetails/getorderdetailbyorderingid/" + orderingId);
            var values = await response.Content.ReadFromJsonAsync<List<ResultOrderDetailDto>>();

            return values;
        }
    }
}
