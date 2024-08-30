using MultiShop.Catalog.Core.DataAccess.Abstract;
using MultiShop.Catalog.Dtos.VendorDtos;
using MultiShop.Catalog.Entities;

namespace MultiShop.Catalog.DataAccess.Abstract
{
    public interface IVendorDal : IRepositoryBase<Vendor, ResultVendorDto, CreateVendorDto, UpdateVendorDto, GetByIdVendorDto>
    {
    }
}
