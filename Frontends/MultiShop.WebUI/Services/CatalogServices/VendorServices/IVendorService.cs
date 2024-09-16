using MultiShop.Dtos.CatalogDtos.VendorDtos;
using MultiShop.WebUI.Services.CatalogServices.GenericServices;

namespace MultiShop.WebUI.Services.CatalogServices.VendorServices
{
    public interface IVendorService : IGenericService<ResultVendorDto, CreateVendorDto, UpdateVendorDto>
    {
    }
}
