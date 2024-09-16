using MultiShop.Dtos.CatalogDtos.OfferDiscountDtos;
using MultiShop.WebUI.Services.CatalogServices.GenericServices;

namespace MultiShop.WebUI.Services.CatalogServices.OfferDiscountServices
{
    public interface IOfferDiscountService : IGenericService<ResultOfferDiscountDto, CreateOfferDiscountDto, UpdateOfferDiscountDto>
    {
    }
}
