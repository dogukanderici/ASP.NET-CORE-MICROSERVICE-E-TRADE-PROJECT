using MultiShop.Dtos.OrderDtos.OrderDetailDtos;

namespace MultiShop.WebUI.Services.OrderServices.OrderOrderDetailService
{
    public interface IOrderDetailService
    {
        Task CreateOrderDetail(List<CreateOrderDetailDto> createOrderDetailDto);
        Task<List<ResultOrderDetailDto>> GetOrderDetail(Guid orderingId);
    }
}
