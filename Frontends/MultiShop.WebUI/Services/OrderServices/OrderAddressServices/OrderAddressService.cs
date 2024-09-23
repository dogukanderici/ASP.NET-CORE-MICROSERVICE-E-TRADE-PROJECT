using MultiShop.Dtos.OrderDtos.OrderAddressDtos;
using System.Collections.Generic;
using System.Net;

namespace MultiShop.WebUI.Services.OrderServices.OrderAddressServices
{
    public class OrderAddressService : IOrderAddressService
    {
        private readonly HttpClient _httpClient;

        public OrderAddressService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<UpdateOrderAddressDto> GetUserOrderAddressAsync(string userId)
        {
            var response = await _httpClient.GetAsync("addresses/" + userId);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var values = await response.Content.ReadFromJsonAsync<UpdateOrderAddressDto>();

                return values;
            }

            return new UpdateOrderAddressDto();
        }

        public async Task CreateOrderAddressAsync(CreateOrderAddressDto createOrderAddressDto)
        {
            await _httpClient.PostAsJsonAsync<CreateOrderAddressDto>("addresses", createOrderAddressDto);
        }

        public async Task UpdateOrderAddressAsync(UpdateOrderAddressDto updateOrderAddressDto)
        {
            await _httpClient.PutAsJsonAsync<UpdateOrderAddressDto>("addresses", updateOrderAddressDto);
        }
    }
}
