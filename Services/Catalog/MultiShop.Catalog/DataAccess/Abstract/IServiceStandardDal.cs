using MultiShop.Catalog.Core.DataAccess.Abstract;
using MultiShop.Catalog.Dtos.ServiceStandardDtos;
using MultiShop.Catalog.Entities;

namespace MultiShop.Catalog.DataAccess.Abstract
{
    public interface IServiceStandardDal : IRepositoryBase<ServiceStandard, ResultServiceStandardDto, CreateServiceStandardDto, UpdateServiceStandardDto, GetByIdServiceStandardDto>
    {
    }
}
