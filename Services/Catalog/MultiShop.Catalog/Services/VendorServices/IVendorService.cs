using MultiShop.Catalog.Dtos.VendorDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Services.GenericServices;

namespace MultiShop.Catalog.Services.VendorServices
{
    public interface IVendorService : IGenericService<Vendor, ResultVendorDto, CreateVendorDto, UpdateVendorDto, GetByIdVendorDto>
    {
    }
}
