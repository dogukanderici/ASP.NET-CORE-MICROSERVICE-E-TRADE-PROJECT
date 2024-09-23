using MultiShop.Dtos.OrderDtos.OrderAddressDtos;

namespace MultiShop.WebUI.Services.OrderServices.OrderAddressServices
{
    public interface IOrderAddressService
    {
        Task<UpdateOrderAddressDto> GetUserOrderAddressAsync(string userId);
        Task CreateOrderAddressAsync(CreateOrderAddressDto createOrderAddressDto);
        Task UpdateOrderAddressAsync(UpdateOrderAddressDto updateOrderAddressDto);
    }
}
