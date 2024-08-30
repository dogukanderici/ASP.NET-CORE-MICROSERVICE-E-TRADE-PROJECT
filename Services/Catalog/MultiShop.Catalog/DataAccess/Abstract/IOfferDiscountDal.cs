using MultiShop.Catalog.Core.DataAccess.Abstract;
using MultiShop.Catalog.Dtos.OfferDiscountDtos;
using MultiShop.Catalog.Entities;

namespace MultiShop.Catalog.DataAccess.Abstract
{
    public interface IOfferDiscountDal : IRepositoryBase<OfferDiscount, ResultOfferDiscountDto, CreateOfferDiscountDto, UpdateOfferDiscountDto, GetByIdOfferDiscountDto>
    {
    }
}
