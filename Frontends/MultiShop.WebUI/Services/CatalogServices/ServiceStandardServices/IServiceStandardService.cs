using MultiShop.Dtos.CatalogDtos.ServiceStandardDtos;
using MultiShop.WebUI.Services.CatalogServices.GenericServices;

namespace MultiShop.WebUI.Services.CatalogServices.ServiceStandardServices
{
    public interface IServiceStandardService : IGenericService<ResultServiceStandardDto, CreateServiceStandardDto, UpdateServiceStandardDto>
    {
    }
}
