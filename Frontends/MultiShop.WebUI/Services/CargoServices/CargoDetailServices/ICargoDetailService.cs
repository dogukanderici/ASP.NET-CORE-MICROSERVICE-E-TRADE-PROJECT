using MultiShop.Dtos.CargoDtos.CargoDetailDtos;
using MultiShop.WebUI.Services.CargoServices.CargoGenericServices;

namespace MultiShop.WebUI.Services.CargoServices.CargoDetailServices
{
    public interface ICargoDetailService : IGenericService<ResultCargoDetailDto, CreateCargoDetailDto, UpdateCargoDetailDto>
    {
    }
}
