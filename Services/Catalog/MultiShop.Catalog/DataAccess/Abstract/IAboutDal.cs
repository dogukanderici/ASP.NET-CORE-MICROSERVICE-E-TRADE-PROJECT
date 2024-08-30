using MultiShop.Catalog.Core.DataAccess.Abstract;
using MultiShop.Catalog.Dtos.AboutDtos;
using MultiShop.Catalog.Entities;

namespace MultiShop.Catalog.DataAccess.Abstract
{
    public interface IAboutDal : IRepositoryBase<About, ResultAboutDto, CreateAboutDto, UpdateAboutDto, GetByIdAboutDto>
    {
    }
}
