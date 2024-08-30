using MultiShop.Catalog.Dtos.OfferDiscountDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Services.GenericServices;

namespace MultiShop.Catalog.Services.OfferDiscountServices
{
    public interface IOfferDiscountService : IGenericService<OfferDiscount, ResultOfferDiscountDto, CreateOfferDiscountDto, UpdateOfferDiscountDto, GetByIdOfferDiscountDto>
    {
    }
}
