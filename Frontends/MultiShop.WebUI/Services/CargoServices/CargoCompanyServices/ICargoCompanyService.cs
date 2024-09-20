using MultiShop.Dtos.CargoDtos.CargoCompanyDtos;
using MultiShop.WebUI.Services.CargoServices.CargoGenericServices;

namespace MultiShop.WebUI.Services.CargoServices.CargoCompanyServices
{
    public interface ICargoCompanyService : IGenericService<ResultCargoCompanyDto, CreateCargoCompanyDto, UpdateCargoCompanyDto>
    {
    }
}
