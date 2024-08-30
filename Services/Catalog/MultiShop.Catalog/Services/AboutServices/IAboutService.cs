using MultiShop.Catalog.Dtos.AboutDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Services.GenericServices;

namespace MultiShop.Catalog.Services.AboutServices
{
    public interface IAboutService : IGenericService<About, ResultAboutDto, CreateAboutDto, UpdateAboutDto, GetByIdAboutDto>
    {
    }
}
