using MultiShop.Dtos.OrderDtos.OrderingDtos;

namespace MultiShop.WebUI.Services.OrderServices.OrderOrderingServices
{
    public interface IOrderOrderingService
    {
        Task<List<ResultOrderingByUserIdDto>> GetOrderingByUserId(string userId);
        Task CreateOrdering(CreateOrderingDto createOrderingDto);
    }
}
