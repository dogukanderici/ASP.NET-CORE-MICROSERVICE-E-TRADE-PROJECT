using AutoMapper;
using MultiShop.Catalog.Core.DataAccess.Concrete;
using MultiShop.Catalog.DataAccess.Abstract;
using MultiShop.Catalog.Dtos.VendorDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings.Abstract;

namespace MultiShop.Catalog.DataAccess.Concrete
{
    public class MongoVendorDal : MongoRepositoryBase<Vendor, ResultVendorDto, CreateVendorDto, UpdateVendorDto, GetByIdVendorDto>, IVendorDal
    {
        public MongoVendorDal(IMapper mapper, IDatabaseSettings databaseSettings, IConfiguration configuration, string collectionName) : base(mapper, databaseSettings, configuration, collectionName)
        {
        }
    }
}
