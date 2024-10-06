using MultiShop.Dtos.CargoDtos.CargoOperationsDtos;
using MultiShop.WebUI.Services.CargoServices.CargoGenericServices;

namespace MultiShop.WebUI.Services.CargoServices.CargoOperationsServices
{
    public interface ICargoOperationService : IGenericService<ResultcargoOperationDto, CreateCargoOperationDto, UpdateCargoOperationDto>
    {
    }
}
