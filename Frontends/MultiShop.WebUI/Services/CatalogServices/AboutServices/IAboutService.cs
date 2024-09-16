using MultiShop.Dtos.CatalogDtos.AboutDtos;
using MultiShop.WebUI.Services.CatalogServices.GenericServices;

namespace MultiShop.WebUI.Services.CatalogServices.AboutServices
{
    public interface IAboutService : IGenericService<ResultAboutDto, CreateAboutDto, UpdateAboutDto>
    {
    }
}
