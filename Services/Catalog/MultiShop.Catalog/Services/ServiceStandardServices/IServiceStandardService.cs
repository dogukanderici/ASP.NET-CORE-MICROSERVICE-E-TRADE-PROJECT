using MultiShop.Catalog.Dtos.ServiceStandardDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Services.GenericServices;

namespace MultiShop.Catalog.Services.ServiceStandardServices
{
    public interface IServiceStandardService : IGenericService<ServiceStandard, ResultServiceStandardDto, CreateServiceStandardDto, UpdateServiceStandardDto, GetByIdServiceStandardDto>
    {
    }
}
