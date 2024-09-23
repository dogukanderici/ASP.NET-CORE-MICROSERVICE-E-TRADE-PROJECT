using MultiShop.Dtos.CargoDtos.CargoCustomerDtos;

namespace MultiShop.WebUI.Services.CargoServices.CargoCustomerServices
{
    public interface ICargoCustomerService
    {
        Task<GetByIdCargoCustomerDto> GetByIdCargoCustomerAsync(string id);
    }
}
