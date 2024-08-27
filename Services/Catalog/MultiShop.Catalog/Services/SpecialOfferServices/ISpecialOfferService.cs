using MultiShop.Catalog.Dtos.SpecialOfferDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Services.GenericServices;

namespace MultiShop.Catalog.Services.SpecialOfferServices
{
    public interface ISpecialOfferService : IGenericService<SpecialOffer, ResultSpecialOfferDto, CreateSpecialOfferDto, UpdateSpecialOfferDto, GetByIdSpecialOfferDto>
    {
    }
}
