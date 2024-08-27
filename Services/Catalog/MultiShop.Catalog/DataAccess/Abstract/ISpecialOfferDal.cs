using MultiShop.Catalog.Core.DataAccess.Abstract;
using MultiShop.Catalog.Dtos.SpecialOfferDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Services.GenericServices;

namespace MultiShop.Catalog.DataAccess.Abstract
{
    public interface ISpecialOfferDal : IRepositoryBase<SpecialOffer, ResultSpecialOfferDto, CreateSpecialOfferDto, UpdateSpecialOfferDto, GetByIdSpecialOfferDto>
    {
    }
}
